using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace ApiSeed.Api.Infrastructure.ErrorHandling
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            context.Result = new CustomInternalServerErrorResult(context.Request);
            return Task.FromResult(0);
        }
    }

    internal class CustomInternalServerErrorResult : InternalServerErrorResult
    {
        public CustomInternalServerErrorResult(HttpRequestMessage request) : base(request)
        {
        }

        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = Request.CreateResponse(HttpStatusCode.InternalServerError, new ErrorResponse("Server error"));
            return Task.FromResult(response);
        }
    }
}