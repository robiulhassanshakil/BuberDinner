using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext cotext)
    {
        try
        {
            await _next(cotext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(cotext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext cotext, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "An error occourred while processing your request." });
        cotext.Response.ContentType = "application/json";
        cotext.Response.StatusCode = (int)code;
        return cotext.Response.WriteAsync(result);
    }
}