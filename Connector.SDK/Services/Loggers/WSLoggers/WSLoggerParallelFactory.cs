using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Connector.SDK.Services.Loggers.WSLoggers
{
    public class WSLoggerParallelFactory<T> : IWSLogger
        where T : class, IWSLogger
    {
        readonly Container container;

        public WSLoggerParallelFactory(Container container)
        {
            this.container = container;
        }

        private IWSLogger GetInstance() => container.GetInstance<T>();

        public int Send(
                string Url,
                string OperationName,
                string Message
            )
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                return GetInstance().Send(Url, OperationName, Message);
        }

        public void Receive(
                int Id,
                string Message,
                string Body
            )
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                GetInstance().Receive(Id, Message, Body);
        }
    }
}