using Connector.Tasks.ServiceFactory;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using static Connector.Common.ServiceNames;

namespace Connector.SDK.Services.ServiceFactory
{
    public class ServiceFactory : IServiceFactory
    {
        readonly IEnumerable<IEndpointBehavior> behaviors;

        public ServiceFactory(
            IEnumerable<IEndpointBehavior> behaviors
        )
        {
            this.behaviors = behaviors;
        }

        public T Create<T>(string JobCode, AXServices Service)
           where T : class, ICommunicationObject
        {
            return _Create<T>(JobCode, Service.ToString());
        }

        private T _Create<T>(string JobCode, string Service)
            where T : class, ICommunicationObject
        {
            Type type = typeof(T);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(Binding), typeof(EndpointAddress) });
            Binding binding = CreateBinding(JobCode);
            EndpointAddress address = new EndpointAddress(new Uri("http://localhost:1579/"));
            T service = (T)constructor.Invoke(new object[] { binding, address });

            PropertyInfo endpointPropertyInfo = typeof(T).GetProperty("Endpoint", BindingFlags.Instance | BindingFlags.Public);
            ServiceEndpoint endpoint = (ServiceEndpoint)endpointPropertyInfo.GetValue(service);

            foreach (IEndpointBehavior behavior in behaviors)
                endpoint.EndpointBehaviors.Add(behavior);

            return service;
        }

        private Binding CreateBinding(string JobCode)
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Name = JobCode + "_netTCPBinding";

            binding.CloseTimeout = TimeSpan.FromMinutes(30);
            binding.OpenTimeout = TimeSpan.FromMinutes(30);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(30);
            binding.SendTimeout = TimeSpan.FromMinutes(30);

            binding.MaxBufferPoolSize = 314572800;
            binding.MaxBufferSize = 104857600;
            binding.MaxConnections = 200;
            binding.MaxReceivedMessageSize = 104857600;

            binding.TransferMode = TransferMode.Buffered;

            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
            {
                MaxArrayLength = 524288,
                MaxBytesPerRead = 104857600,
                MaxDepth = 64,
                MaxNameTableCharCount = 16384000,
                MaxStringContentLength = 104857600
            };

            return binding;
        }
    }
}