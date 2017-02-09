using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace ApiSeed.Api.Security
{
    public interface ITokenManager
    {
        IPrincipal ParseToken(string tokenString);

        string CreateToken(IEnumerable<Claim> claims);
    }

    public class InvalidTokenFormatException : Exception { }

    public class TokenManager : ITokenManager
    {
        private IRSAProvider _rsa;
        private ISecurityConfigurationProvider _configProvider;

        private SecurityConfiguration _config;

        private SecurityConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    _config = _configProvider.Load();
                }
                return _config;
            }
        }

        public TokenValidationParameters ValidationParameters
        {
            get
            {
                return LoadTokenValidationParameters();
            }
        }

        public TokenManager(IRSAProvider rsa, ISecurityConfigurationProvider configProvider)
        {
            _rsa = rsa;
            _configProvider = configProvider;
        }

        /// <summary>
        /// Parse and validate token
        /// </summary>
        /// <param name="tokenString"></param>
        /// <returns></returns>
        /// <exception cref="InvalidTokenFormatException">Invalid token format</exception>
        public IPrincipal ParseToken(string tokenString)
        {
            JwtSecurityToken token;
            try
            {
                token = new JwtSecurityToken(tokenString);
            }
            catch (ArgumentException)
            {
                throw new InvalidTokenFormatException();
            }
            var validationParameters = LoadTokenValidationParameters();

            SecurityToken validatedToken;
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(tokenString, validationParameters, out validatedToken);
                return claimsPrincipal;
            }
            catch (SecurityTokenValidationException)
            {
                // ignore if invalid or expired
                return null;
            }
        }

        private TokenValidationParameters LoadTokenValidationParameters()
        {
            var parameters = new TokenValidationParameters()
            {
                ValidIssuer = Config.TokenIssuer,
                ValidAudience = Config.TokenAudience,
                IssuerSigningKey = new RsaSecurityKey(_rsa.GetRSA(Config.SigningKeyFile)),
                ClockSkew = TimeSpan.Zero
            };
            return parameters;
        }

        public string CreateToken(IEnumerable<Claim> claims)
        {
            var validFrom = DateTime.UtcNow;
            var validTo = validFrom.Add(Config.TokenLifetime);
            var token = new JwtSecurityToken(
                issuer: Config.TokenIssuer,
                audience: Config.TokenAudience,
                claims: claims,
                notBefore: validFrom,
                expires: validTo,
                signingCredentials: new SigningCredentials(
                    new RsaSecurityKey(_rsa.GetRSA(Config.SigningKeyFile)),
                    SecurityAlgorithms.RsaSha512
                )
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}