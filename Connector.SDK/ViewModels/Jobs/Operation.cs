using System;

namespace Connector.SDK.ViewModels.Jobs
{
    public class Operation
    {
        public int Id { get; set; }

        public string JobCode { get; set; }

        public string Job { get; set; }

        public string JobIcon { get; set; }

        public string StatusCode { get; set; }

        public string Status { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime? EndedOn { get; set; }

        public bool Running { get; set; }

        public bool ForcedRunning { get; set; }
    }
}