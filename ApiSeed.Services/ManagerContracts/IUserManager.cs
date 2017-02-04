using ApiSeed.Models.Common;
using ApiSeed.Models.Common.StatusCodes;
using ApiSeed.Models.Users.Commands;
using ApiSeed.Models.Users.Models;

namespace ApiSeed.Services.ManagerContracts
{
    public interface IUserManager
    {
        User GetByCredentials(Credentials credentials);

        User GetById(string id);

        StatusResult RegisterUser(RegisterUserCommand regModel);
    }
}