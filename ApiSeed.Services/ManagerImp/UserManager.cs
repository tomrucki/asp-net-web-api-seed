using ApiSeed.Models.Common;
using ApiSeed.Models.Common.StatusCodes;
using ApiSeed.Models.Users.Commands;
using ApiSeed.Models.Users.Models;
using ApiSeed.Services.ManagerContracts;
using System;

namespace ApiSeed.Services.ManagerImp
{
    public class UserManager : IUserManager
    {
        public User GetByCredentials(Credentials credentials)
        {
            return new User { Id = "123" };
            throw new NotImplementedException();
        }

        public User GetById(string id)
        {
            throw new NotImplementedException();
        }

        public StatusResult RegisterUser(RegisterUserCommand regModel)
        {
            throw new NotImplementedException();
        }
    }
}