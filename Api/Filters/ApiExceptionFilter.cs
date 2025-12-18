using Momona.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Momona.Api.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<ApiExceptionFilterAttribute> _logger;

    public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);
        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case NotFoundException notFoundException:
                context.Result = new NotFoundObjectResult(new { error = notFoundException.Message });
                context.ExceptionHandled = true;
                break;
            case FluentValidation.ValidationException validationException:
                context.Result = new BadRequestObjectResult(new { errors = validationException.Errors });
                context.ExceptionHandled = true;
                break;
            default:
                // _logger.LogError(context.Exception, "Unhandled exception");
                // Optional: Let Middleware handle generic 500
                break;
        }
    }
}
