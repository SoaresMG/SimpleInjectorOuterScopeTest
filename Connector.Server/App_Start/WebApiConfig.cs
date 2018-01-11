using Connector.SDK.Filters.Exceptions;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Connector.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, Container container)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Register Services
            config.Services.Add(typeof(IExceptionLogger), new HumbleExceptionLogger<IExceptionLogger>(container));

            // Web API routes
            AddRoutes(config);
            config.EnsureInitialized();
        }

        private static void AddRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
