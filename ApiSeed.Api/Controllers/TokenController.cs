using ApiSeed.Api.Security;
using ApiSeed.Models.Common.StatusCodes;
using ApiSeed.Models.Users.Models;
using ApiSeed.Services.ManagerContracts;
using System.Security.Claims;
using System.Web.Http;

namespace ApiSeed.Api.Controllers
{
    [Route("token")]
    public class TokenController : BaseApiController
    {
        private IUserManager _userManager;
        private ITokenManager _tokenManager;

        public TokenController(IUserManager userManager, ITokenManager tokenManager)
        {
            _userManager = userManager;
            _tokenManager = tokenManager;
        }

        public IHttpActionResult Post([FromBody]Credentials creds)
        {
            var user = _userManager.GetByCredentials(creds);
            if (user == null)
            {
                return AsFail(ErrorCodes.Auth.InvalidCredentials);
            }
            var userClaims = user.GetClaims();
            var tokenString = _tokenManager.CreateToken(userClaims);
            return AsOk(tokenString);
        }
    }
}