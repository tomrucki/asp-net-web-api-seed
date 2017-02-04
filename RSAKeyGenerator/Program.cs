using System;
using System.IO;

namespace RSAKeyGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You must specify an output directory");
                return;
            }

            var outputDirectory = args[0];
            var pubkeyonlyFilename = Path.Combine(outputDirectory, "rsa_key_public.xml");
            var keyFileName = Path.Combine(outputDirectory, "rsa_key.xml");
            RSAHelper.GenerateKeyPairToFile(pubkeyonlyFilename, keyFileName);
            Console.WriteLine("keys generated ...");
        }
    }
}