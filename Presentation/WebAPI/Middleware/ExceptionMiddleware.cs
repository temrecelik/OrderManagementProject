using System.Net;
using System.Net.Mime;
using Application.Excepetions;
using Application.Logging.Serilog.Logger;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ValidationProblemDetails = Application.Excepetions.ValidationProblemDetails;


namespace WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly DatabaseLogger _databaseLogger;
    private readonly FileLogger _fileLogger;

    public ExceptionMiddleware(RequestDelegate next, DatabaseLogger databaseLogger, FileLogger fileLogger)
    {
        _next = next;
        _databaseLogger = databaseLogger;
        _fileLogger = fileLogger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
            _databaseLogger.Error(exception.Message);
            _fileLogger.Error(exception.Message);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;

        if (exception.GetType() == typeof(BusinessException)) return CreateBusinessException(context, exception);
        if (exception.GetType() == typeof(ValidationException)) return CreateValidationException(context, exception);
        if (exception.GetType() == typeof(AuthorizationException)) return CreateAuthorizationException(context, exception);

        return CreateInternalException(context, exception);
    }

    private Task CreateAuthorizationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

        return context.Response.WriteAsync(new AuthorizationProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Type = "https://example.com/probs/authorization",
            Title = "Authorization exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateBusinessException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

        return context.Response.WriteAsync(new BusinessProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://example.com/probs/business",
            Title = "Business exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }

    private Task CreateValidationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        object errors = ((ValidationException)exception).Errors;

        return context.Response.WriteAsync(new ValidationProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://example.com/probs/validation",
            Title = "Validation error(s)",
            Detail = "",
            Instance = "",
            Errors = errors
        }.ToString());
    }

    private Task CreateInternalException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

        return context.Response.WriteAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://example.com/probs/internal",
            Title = "Internal exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString()!);
    }
}