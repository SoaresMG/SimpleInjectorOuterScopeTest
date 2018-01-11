using Connector.SDK.ViewModels.Core;

namespace Connector.SDK.ViewModels.Logs
{
    public class WSLogViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int OperationId { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string MessageSent { get; set; }

        public string MessageReceived { get; set; }

        public string BodyReceived { get; set; }

        public bool HasRequest { get; set; }

        public bool HasReply { get; set; }

        public int ElapsedTime { get; set; }
    }
}