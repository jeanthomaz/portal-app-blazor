using Api.Authentication;
using Api.Reponses;
using Core.DTOs;
using Core.Exceptions;
using Core.Interfaces;
using Core.Services;
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

app.Run();