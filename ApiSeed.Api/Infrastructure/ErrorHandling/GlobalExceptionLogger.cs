using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace ApiSeed.Api.Infrastructure.ErrorHandling
{
    public class GlobalExceptionLogger : IExceptionLogger
    {
        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            // todo: log error
            return Task.FromResult(0);
        }
    }
}