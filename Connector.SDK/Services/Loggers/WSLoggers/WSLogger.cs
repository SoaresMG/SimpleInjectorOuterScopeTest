using Connector.Tasks.Configuration;

namespace Connector.SDK.Services.Loggers.WSLoggers
{
    public class WSLogger : IWSLogger
    {
        readonly IOperationScope scope;

        public WSLogger(
                IOperationScope scope
            )
        {
            this.scope = scope;
        }

        public int Send(
                string Url,
                string OperationName,
                string Message
            )
        {
            // Omitted; use IOperationScope here;
            return 0;
        }

        public void Receive(
                int Id,
                string Message,
                string Body
            )
        {
            // Omitted; use IOperationScope here;
        }
    }
}