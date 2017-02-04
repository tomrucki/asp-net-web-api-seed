using System;
using System.Configuration;

namespace ApiSeed.Api.Security
{
    public interface ISecurityConfigurationProvider
    {
        SecurityConfiguration Load();
    }

    public class SecurityConfigurationProvider : ISecurityConfigurationProvider
    {
        public SecurityConfiguration Load()
        {
            var config = new SecurityConfiguration
            {
                SigningKeyFile = ConfigurationManager.AppSettings["security:SigningKeyFile"],
                TokenIssuer = ConfigurationManager.AppSettings["security:TokenIssuer"],
                TokenAudience = ConfigurationManager.AppSettings["security:TokenAudience"],
                TokenLifetime = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["security:TokenLifetimeSec"]))
            };
            return config;
        }
    }
}