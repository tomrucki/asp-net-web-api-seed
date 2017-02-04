using ApiSeed.Models.Common.StatusCodes;
using ApiSeed.Models.Users.Commands;
using ApiSeed.Services.ServiceContracts;
using System.Web.Http;

namespace ApiSeed.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : BaseApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IHttpActionResult Get(string id)
        {
            var user = _userService.UserManager.GetById(id);
            if (user == null)
            {
                return AsFail(statusCode: ErrorCodes.Common.NotFound);
            }
            return AsOk(user);
        }

        [Route("register")]
        [HttpPost, AllowAnonymous]
        public IHttpActionResult Register([FromBody]RegisterUserCommand command)
        {
            var result = _userService.RegisterUser(command);
            return AsOk(result);
        }
    }
}