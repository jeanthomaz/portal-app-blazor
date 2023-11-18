using Core.Interfaces;

namespace Api.Authentication;

public class ApiKeyAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    
    public ApiKeyAuthMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }
    
    public async Task InvokeAsync(HttpContext context, IService service)
    {
        if (context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out var apiKey))
        {
            var adminToken = _configuration[AuthConstants.AdminApiToken];
            
            var tokens = await service.ListTokensAsync();
            var token = tokens.FirstOrDefault(t => t.Id == apiKey);
            
            if (token is not null || apiKey == adminToken)
            {
                await _next(context);
                return;
            }
        }
        
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Necessário informar um token válido");
    }
}