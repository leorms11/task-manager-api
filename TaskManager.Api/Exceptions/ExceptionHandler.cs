using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TaskManager.Communication;
using TaskManager.Communication.Exceptions;
using TaskManager.Communication.Responses;

namespace TaskManager.Api.Exceptions;

public class ExceptionHandler : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseTaskException baseException)
        {
            context.HttpContext.Response.StatusCode = (int)baseException.StatusCode;
            context.Result = new JsonResult(new ErrorsResponse
            {
                Message = baseException.Message,
                RejectionReasons = baseException.Errors
            });

            return;
        }
        
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new JsonResult(new ErrorsResponse
        {
            Message = ResourceErrorMessages.INTERNAL_SERVER_ERROR
        });
    }
}