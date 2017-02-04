using ApiSeed.Api.Infrastructure;
using ApiSeed.Api.Infrastructure.ErrorHandling;
using ApiSeed.Api.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using WebApiContrib.IoC.StructureMap;

namespace ApiSeed.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureIoC(config);
            ConfigureSecurity(config);
            ConfigureRouting(config);
            ConfigureErrorHandling(config);
            ConfigureJson(config);
        }

        private static void ConfigureJson(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private static void ConfigureErrorHandling(HttpConfiguration config)
        {
            // specific cases
            config.Filters.Add(new ValidationExceptionFilterAttribute());

            // global
            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
        }

        private static void ConfigureRouting(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ConfigureSecurity(HttpConfiguration config)
        {
            config.Filters.Add(new TokenAuthenticationFilterAttribute(Ioc.Container.GetInstance<ITokenManager>()));

            // enable requests from javascript originating from any domain
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }

        private static void ConfigureIoC(HttpConfiguration config)
        {
            Ioc.Init();
            config.DependencyResolver = new StructureMapResolver(Ioc.Container);
        }
    }
}