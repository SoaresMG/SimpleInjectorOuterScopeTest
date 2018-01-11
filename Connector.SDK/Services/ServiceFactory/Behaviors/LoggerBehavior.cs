using SimpleInjector;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Connector.SDK.Services.ServiceFactory
{
    public class LoggerBehavior : IEndpointBehavior
    {
        readonly Container container;
        public LoggerBehavior(Container container)
        {
            this.container = container;
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            => clientRuntime.MessageInspectors.Add(container.GetInstance<IClientMessageInspector>());

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

        public void Validate(ServiceEndpoint endpoint) { }
    }
}