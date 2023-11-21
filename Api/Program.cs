using Api.Authentication;
using Api.Reponses;
using Core.DTOs;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
using Core.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// injeta dependências
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, Service>();

// adiciona swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "Autenticação por chave de API",
        Name = AuthConstants.ApiKeyHeaderName,
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyScheme"
    });
    
    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        }
    };
    
    var requirement = new OpenApiSecurityRequirement
    {
        { scheme, Array.Empty<string>() }
    };
    
    c.AddSecurityRequirement(requirement);
});

var app = builder.Build();

void ApplyMigrations(ApplicationDbContext context)
{
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    ApplyMigrations(context);
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ApiKeyAuthMiddleware>();

app.MapGet("/api/v1/tokens", async (IService service) =>
{
    var tokens = await service.ListTokensAsync();
    return tokens;
}).WithTags("[Admin] Tokens");


app.MapGet("/api/v1/generate-token", async (IService service) =>
{
    var token = await service.GenerateTokenAsync();

    GenerateTokenResponse response = new() { Token = token };

    return Results.Ok(response);
}).WithTags("[Admin] Tokens");


app.MapGet("/api/v1/projects", async (IService service) =>
{
    var projects = await service.ListProjectsAsync();
    
    var projectsDto = new List<ProjectDto>();
    
    foreach (var project in projects)
    {
        var projectDto = new ProjectDto
        {
            Name = project.Name,
            Description = project.Description,
            TextBody = project.TextBody,
            References = project.References.Select(r => r.ToString()).ToList(),
            Group = new GroupDto(project.Group)
        };
        
        projectsDto.Add(projectDto);
    }
    
    return projectsDto;
});

app.MapPost("/api/v1/create-project", async (HttpRequest request, IService service, ProjectDto projectDto) =>
{
    try
    {
        var project = projectDto.ToProject();
        
        var token = request.Headers[AuthConstants.ApiKeyHeaderName].ToString();
        var tokenAsGuid = Guid.Parse(token);

        await service.AddProjectAsync(project, tokenAsGuid);
        return Results.Created($"/api/v1/projects/{project.Id}", project);
    }
    catch (Exception e)
    {
        if (e is UnavailableTokenException)
            return Results.Problem(e.Message, statusCode: 403);
        
        Console.WriteLine(e);
        return Results.StatusCode(500);
    }
});

app.MapGet("/api/v1/projects/{id}", async (string id) =>
{
    try
    {
        var usingScope = app.Services.CreateScope();
        var service = usingScope.ServiceProvider.GetRequiredService<IService>();
        
        var guid = Guid.Parse(id);
        var project = await service.GetProjectByIdAsync(guid);
        
        var projectDto = new ProjectDto
        {
            Name = project.Name,
            Description = project.Description,
            TextBody = project.TextBody,
            References = project.References.Select(r => r.ToString()).ToList(),
            Group = new GroupDto(project.Group)
        };
        
        return Results.Ok(projectDto);
    }
    catch (Exception e)
    {
        if (e is NotFoundExcecption)
            return Results.NotFound(e.Message);
        
        Console.WriteLine(e);
        return Results.StatusCode(500);
    }
});

app.MapPut("/api/v1/projects/{id}", async (HttpRequest request, string id, IService service, ProjectDto projectDto) =>
{
    try
    {
        var guid = Guid.Parse(id);
        var project = await service.GetProjectByIdAsync(guid);
        
        var token = request.Headers[AuthConstants.ApiKeyHeaderName].ToString();
        var tokenAsGuid = Guid.Parse(token);
        
        if (project.PrivateToken != tokenAsGuid)
            return Results.Forbid();
        
        project.Name = projectDto.Name;
        project.Description = projectDto.Description;
        project.TextBody = projectDto.TextBody;
        project.References = projectDto.References.Select(r => new Url(r)).ToList();
        
        await service.UpdateProjectAsync(project, tokenAsGuid);
        
        return Results.Ok(project);
    }
    catch (Exception e)
    {
        if (e is NotFoundExcecption)
            return Results.NotFound(e.Message);
        
        Console.WriteLine(e);
        return Results.StatusCode(500);
    }
});

app.MapDelete("/api/v1/projects/{id}", async (string id, IService service, HttpRequest request) =>
{
    try
    {
        var guid = Guid.Parse(id);
        var project = await service.GetProjectByIdAsync(guid);
        
        var token = request.Headers[AuthConstants.ApiKeyHeaderName].ToString();
        var tokenAsGuid = Guid.Parse(token);
        
        if (project.PrivateToken != tokenAsGuid)
            return Results.Forbid();
        
        await service.RemoveProjectAsync(project, tokenAsGuid);
        
        return Results.Ok();
    }
    catch (Exception e)
    {
        if (e is NotFoundExcecption)
            return Results.NotFound(e.Message);
        
        Console.WriteLine(e);
        return Results.StatusCode(500);
    }
});

app.Run();