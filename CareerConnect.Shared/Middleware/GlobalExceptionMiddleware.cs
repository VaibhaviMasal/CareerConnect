using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using CareerConnect.Shared.Exceptions;

namespace CareerConnect.Shared.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        int statusCode = ex switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            NotFoundException => StatusCodes.Status404NotFound,
            ConflictException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        response.StatusCode = statusCode;

        var result = JsonSerializer.Serialize(new
        {
            message = ex.Message,
            statusCode
        });

        await response.WriteAsync(result);
    }
}