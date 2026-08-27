using IBS.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IBS.Api.Middleware;

/// <summary>
/// Translates the domain exceptions into RFC 7807 problem responses, so every controller can
/// let a rule throw rather than each one shaping its own error payload.
/// </summary>
public sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await WriteProblemAsync(context, ex);
        }
    }

    private async Task WriteProblemAsync(HttpContext context, Exception ex)
    {
        var (status, title, detail, code) = ex switch
        {
            NotFoundException nf => (StatusCodes.Status404NotFound, "Not found", nf.Message, (string?)null),
            ForbiddenException f => (StatusCodes.Status403Forbidden, "Forbidden", f.Message, null),
            ConflictException c => (StatusCodes.Status409Conflict, "Conflict", c.Message, null),
            BusinessRuleException b => (StatusCodes.Status400BadRequest, "Request rejected", b.Message, b.Code),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "Not signed in",
                "This request requires a signed-in employee.", null),
            _ => (StatusCodes.Status500InternalServerError, "Unexpected error",
                "Something went wrong handling this request.", null)
        };

        if (status == StatusCodes.Status500InternalServerError)
        {
            // Only the genuinely unexpected is logged as an error; a rejected rule is not a fault.
            logger.LogError(ex, "Unhandled exception while handling {Method} {Path}.",
                context.Request.Method, context.Request.Path);
        }
        else
        {
            logger.LogInformation("Request rejected with {Status}: {Message}", status, ex.Message);
        }

        if (context.Response.HasStarted)
        {
            return;
        }

        var problem = new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = detail,
            Instance = context.Request.Path
        };

        if (code is not null)
        {
            // Stable machine-readable rule id, so the frontend can branch without string matching.
            problem.Extensions["code"] = code;
        }

        problem.Extensions["traceId"] = context.TraceIdentifier;

        context.Response.StatusCode = status;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problem);
    }
}
