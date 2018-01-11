using System.ServiceModel;
using static Connector.Common.ServiceNames;

namespace Connector.Tasks.ServiceFactory
{
    public interface IServiceFactory
    {
        T Create<T>(string JobCode, AXServices Service)
           where T : class, ICommunicationObject;
    }
}