using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace SBAPI.API.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var problemDetails = new ProblemDetails
        {
            Type="https://tools.ietf.org/html/rf7231#section-6.6.1",
            Title = "Un error ha ocurrido realizando tu solicitud.",
            Status = (int)HttpStatusCode.InternalServerError,
        };

        var errorResult = new { error = "" }; 

        context.Result = new ObjectResult(errorResult)
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;
    }
}
