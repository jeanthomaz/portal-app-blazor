using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                

                // Esquema de autenticação Bearer
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        () { 
                                Reference = new OpenApiReference()
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                        new string [] {}
                    }
                });


                



            });
            return services;

        }
    }
}
