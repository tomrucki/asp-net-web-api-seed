using System;

namespace ApiSeed.Api.Security
{
    public class SecurityConfiguration
    {
        public string SigningKeyFile { get; set; }
        public string TokenIssuer { get; set; }
        public string TokenAudience { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}