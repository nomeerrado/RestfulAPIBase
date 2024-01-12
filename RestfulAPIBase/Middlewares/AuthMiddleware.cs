using RestfulAPIBase.Lib.Services.Token;

namespace RestfulAPIBase.Middlewares;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, TokenService tokenService)
    {
        if (context.Request.Path == "/api/auth/login/sample")
        {
            await _next(context);
            return;
        }

        context.Response.ContentType = "application/json";

        var token = context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        if (!tokenService.TokenValido(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(new { message = "Token inválido." });
            return;
        }

        await _next(context);
    }
}
