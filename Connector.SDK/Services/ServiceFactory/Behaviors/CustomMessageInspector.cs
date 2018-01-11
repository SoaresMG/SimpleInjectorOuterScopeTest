using Connector.SDK.Services.Loggers.WSLoggers;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace Connector.SDK.Services.ServiceFactory
{
    /// <summary>
    /// This must always be transient
    /// </summary>
    public class CustomMessageInspector : IClientMessageInspector
    {
        readonly IWSLogger logger;
        int currentId;

        public CustomMessageInspector(IWSLogger logger)
        {
            this.logger = logger;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();
            Message msg = buffer.CreateMessage();
            StringBuilder sb = new StringBuilder();
            XmlWriter xw = XmlWriter.Create(sb);
            msg.WriteBody(xw);
            xw.Close();

            logger.Receive(currentId, msg.ToString(), sb.ToString());
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var action = request.Headers.Action;
            var operationName = action.Substring(action.LastIndexOf("/") + 1);

            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();

            currentId = logger.Send(action, operationName, buffer.CreateMessage().ToString());

            return null;
        }
    }
}