using ApiSeed.Models.Common.StatusCodes;
using ApiSeed.Models.Users.Commands;
using ApiSeed.Services.ManagerContracts;

namespace ApiSeed.Services.ServiceContracts
{
    public interface IUserService
    {
        IUserManager UserManager { get; }

        StatusResult RegisterUser(RegisterUserCommand command);
    }
}