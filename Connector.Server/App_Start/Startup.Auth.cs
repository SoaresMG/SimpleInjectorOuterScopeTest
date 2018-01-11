using Owin;
using SimpleInjector;

namespace Connector.Server
{
    public static class StartupAuth
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public static void ConfigureAuth(this IAppBuilder app, Container container)
        {
            // Configure Cors
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
