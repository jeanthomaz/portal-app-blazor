using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;
using Api;
using System.Security.Claims;
using Core.Interfaces;
using Core.Services;
using Persistence.Repositories;

public class Program
{
    public static async Task Main(string[] args)
    {
        var tokenKey = "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"; // Sua chave secreta
        var tokenIssuer = "http://localhost:7203"; // Seu emissor

        var tokenGenerator = new Token(tokenKey, tokenIssuer);
        var adminToken = tokenGenerator.GenerateAdminToken();

        var builder = WebApplication.CreateBuilder(args);

        // Injeta dependências (serviços)
        builder.Services.AddDbContext<ApplicationDbContext>();
        builder.Services.AddControllers();
        builder.Services.AddInfrastructureSwagger();    
         builder.Services.AddScoped<StudentService>();

        // Registro do StudentService como Singleton
        builder.Services.AddScoped<IService, Service>();
        builder.Services.AddScoped<IRepository, Repository>();

        // Configuração do Token JWT
        var configuration = builder.Configuration;
        var token = new Token(tokenKey, tokenIssuer); // Crie uma instância da classe Token
        builder.Services.AddSingleton(token);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var configuration = builder.Configuration;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy =>
            {
                policy.RequireClaim(ClaimTypes.Role, "Admin"); // Exige que o usuário tenha a reivindicação de função "Admin"
            });
        });

        var app = builder.Build();
        


        app.MapControllers();

        // Configuração do Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.Run();

        MakeHttpRequestWithJwtToken(adminToken);
    }

    // Método para fazer solicitação HTTP com o token JWT
    static async Task MakeHttpRequestWithJwtToken(string token)
    {
        string apiUrl = "http://localhost:7203/api/students";

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Resposta do servidor:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Erro na solicitação HTTP: " + response.StatusCode);
            }
        }
    }
}
