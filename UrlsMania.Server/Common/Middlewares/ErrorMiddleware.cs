
using Microsoft.AspNetCore.Mvc;

namespace UrlsMania.Server.Common.Middlewares;

public sealed class ErrorMiddleware(ILogger<ErrorMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            context.Response.StatusCode = StatusCodes.Status418ImATeapot;
            await context.Response.WriteAsJsonAsync(
                value: new ProblemDetails
                {
                    Title = "Server Error",
                    Status = StatusCodes.Status418ImATeapot,
                });
        }
    }
}