using Connector.SDK.ViewModels.Core;
using System;

namespace Connector.SDK.ViewModels.Jobs
{
    public class OperationLog : BaseViewModel
    {
        public int Id { get; set; }

        public string JobCode { get; set; }

        public string Job { get; set; }

        public int OperationId { get; set; }

        public Guid? EntryId { get; set; }

        public string Message { get; set; }

        public string Area { get; set; }
    }
}