using StructureMap;
using System;

namespace ApiSeed.Api.Infrastructure
{
    public class Ioc
    {
        public static IContainer Container { get; private set; }

        public static bool IsInitialized { get; private set; }

        public static void Init()
        {
            if (IsInitialized)
            {
                throw new Exception("Can not initiliaze. Ioc has been already initialized");
            }
            ObjectFactory.Initialize(x =>
            {
                InitDefaultScan(x);
            });
            Container = ObjectFactory.Container;
            IsInitialized = true;
        }

        private static void InitDefaultScan(IInitializationExpression x)
        {
            //var thisAssembly = GetType().Assembly;
            x.Scan(scanner =>
            {
                //scanner.Assembly(thisAssembly);
                scanner.AssembliesFromApplicationBaseDirectory(asm => asm.FullName.StartsWith("ApiSeed"));
                scanner.WithDefaultConventions();
            });
        }
    }
}