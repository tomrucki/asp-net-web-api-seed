using ApiSeed.Services.Exceptions;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ApiSeed.Api.Infrastructure.ErrorHandling
{
    public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ValidationException)
            {
                var ex = context.Exception as ValidationException;
                context.Response = context.Request.CreateResponse(new FailResponse(ex.ErrorCode, ex.Message));
            }
        }
    }
}