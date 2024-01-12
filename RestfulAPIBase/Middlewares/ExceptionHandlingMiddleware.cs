using System.Net;

namespace RestfulAPIBase.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            HttpStatusCode? status;
            string message = string.Empty;

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                message = "Unauthorized Access";
            }
            else if (exceptionType == typeof(NullReferenceException))
            {
                status = HttpStatusCode.NotFound;
                message = "Resource not found";
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = "Internal Server Error";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsJsonAsync(new { status, mensagem = message });
        }
    }
}
