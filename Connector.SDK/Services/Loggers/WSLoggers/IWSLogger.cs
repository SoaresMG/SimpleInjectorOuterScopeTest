namespace Connector.SDK.Services.Loggers.WSLoggers
{
    public interface IWSLogger
    {
        /// <summary>
        /// Set the Sending Soap XML
        /// </summary>
        int Send(string Url, string OperationName, string Message);

        /// <summary>
        /// Set the Received Soap XML and body XML
        /// </summary>
        void Receive(int Id, string Message, string Body);
    }
}