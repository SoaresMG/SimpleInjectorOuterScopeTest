using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using SimpleInjector;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(Connector.Server.Startup))]

namespace Connector.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();

            Container container = app.InitializeInjector(app.GetDataProtectionProvider());
            app.ConfigureAuth(container);
        }
    }
}
