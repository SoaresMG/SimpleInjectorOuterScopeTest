using Microsoft.AspNet.SignalR.Hubs;
using SimpleInjector;

namespace Connector.Server
{
    public class SimpleInjectorHubActivator : IHubActivator
    {
        readonly Container _container;

        public SimpleInjectorHubActivator(Container container)
        {
            _container = container;
        }

        public IHub Create(HubDescriptor descriptor) => (IHub)_container.GetInstance(descriptor.HubType);
    }
}
