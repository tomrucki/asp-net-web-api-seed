using ApiSeed.Models.Common.StatusCodes;
using ApiSeed.Models.Users.Commands;
using ApiSeed.Services.ManagerContracts;
using ApiSeed.Services.ServiceContracts;
using System;

namespace ApiSeed.Services.ServiceImp
{
    public class UserService : IUserService
    {
        public IUserManager UserManager
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public StatusResult RegisterUser(RegisterUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}