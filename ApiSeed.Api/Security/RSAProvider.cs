using System.IO;
using System.Security.Cryptography;

namespace ApiSeed.Api.Security
{
    public interface IRSAProvider
    {
        RSA GetRSA(string keyFile);
    }

    public class RSAProvider : IRSAProvider
    {
        public RSA GetRSA(string keyFile)
        {
            var keyXml = File.ReadAllText(keyFile);
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(keyXml);
            return rsa;
        }
    }
}