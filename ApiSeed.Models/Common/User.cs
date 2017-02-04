using System.Collections.Generic;
using System.Security.Claims;

namespace ApiSeed.Models.Common
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public IEnumerable<Claim> GetClaims()
        {
            return new[] 
            {
                new Claim(ClaimTypes.NameIdentifier, Id)
            };
        }
    }
}