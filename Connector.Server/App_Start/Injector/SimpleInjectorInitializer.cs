using Connector.SDK.Injector;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace Connector.Server
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static Container InitializeInjector(this IAppBuilder app, IDataProtectionProvider DataProtectionProvider)
        {
            var container = new Container();

            Mappings.InitializeContainer(container, DataProtectionProvider);
            app.UseOwinContextInjector(container);
            app.MapSignalR(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.EnableHttpRequestMessageTracking(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            //BinderConfig.RegisterModelBinders(GlobalConfiguration.Configuration, container);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, container);
            WebApiConfig.Register(GlobalConfiguration.Configuration, container);
            return container;
        }

        private static void MapSignalR(this IAppBuilder app, Container container)
        {
            var activator = new SimpleInjectorHubActivator(container);
            GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => activator);
            app.MapSignalR();
        }

        public static void UseOwinContextInjector(this IAppBuilder app, Container container)
        {
            // Create an OWIN middleware to create an execution context scope
            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    await next();
                }
            });
        }
    }
}
