using ApiSeed.Api.Infrastructure;
using ApiSeed.Models.Common.StatusCodes;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace ApiSeed.Api.Security
{
    public class TokenAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
    {
        private ITokenManager _tokenManager;

        public TokenAuthenticationFilterAttribute(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public bool AllowMultiple
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Authenticates the request by validating bearer token in the request, if present
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;
            if (authorization == null || authorization.Scheme != "Bearer")
            {
                return Task.CompletedTask;
            }
            try
            {
                var principal = _tokenManager.ParseToken(authorization.Parameter);
                if (principal == null)
                {
                    context.Principal = principal;
                }
                else
                {
                    var response = request.CreateResponse(new FailResponse(ErrorCodes.Auth.Expired));
                    context.ErrorResult = new ResponseMessageResult(response);
                }
            }
            catch (InvalidTokenFormatException)
            {
                var response = request.CreateResponse(new FailResponse(ErrorCodes.Auth.InvalidFormat));
                context.ErrorResult = new ResponseMessageResult(response);
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Adds an authentication challenge to the HTTP response, if needed
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}