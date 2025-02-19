using BookManagement.API.Models;
using BookManagement.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BookManagement.API.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        string exceptionMessage = $"Exception: {exception.Message}";
        string innerExceptionMessage = exception.InnerException?.Message;

        if (!string.IsNullOrWhiteSpace(innerExceptionMessage))
        {
            exceptionMessage += $", InnerException: {innerExceptionMessage}";
        }

        (int statusCode, string message) = exception switch
        {
            NotFoundException => (404, exceptionMessage),
            KeyNotFoundException => (404, exceptionMessage),
            UnauthorizedException => (401, exceptionMessage),
            DuplicateTitleException => (409, exceptionMessage),
            BadRequestException => (400, exceptionMessage),
            _ => (500, "An error occurred while processing your request.")
        };

        var errorDetails = new ErrorDetails
        {
            StatusCode = statusCode,
            Message = message
        };

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(errorDetails, cancellationToken);

        return true;
    }
}
