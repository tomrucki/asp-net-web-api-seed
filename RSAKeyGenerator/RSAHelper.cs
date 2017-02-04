using System.IO;
using System.Security.Cryptography;

namespace RSAKeyGenerator
{
    public class RSAHelper
    {
        public static void GenerateKeyPairToFile(string pubkeyFile, string keyFile, int keySize = 2048)
        {
            var myRSA = new RSACryptoServiceProvider(keySize);
            var key = myRSA.ToXmlString(includePrivateParameters: true);
            var pubKeyOnly = myRSA.ToXmlString(includePrivateParameters: false);

            File.WriteAllText(pubkeyFile, pubKeyOnly);
            File.WriteAllText(keyFile, key);
        }

        public static RSA FromKeyFile(string filePath)
        {
            var fileText = File.ReadAllText(filePath);
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(fileText);
            return rsa;
        }
    }
}