using Connector.SDK.ViewModels.Core;
using System;

namespace Connector.SDK.ViewModels.Jobs
{
    public class OperationEntry : BaseViewModel
    {
        public Guid Id { get; set; }

        public string JobCode { get; set; }

        public int OperationId { get; set; }

        public string StatusCode { get; set; }

        public string Status { get; set; }

        public string Payload { get; set; }

        public string Action { get; set; }

        public bool Editable { get; set; }
    }
}