using System;
using System.Collections.Generic;

namespace Connector.SDK.ViewModels.Jobs
{
    public class Job
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string IconName { get; set; }

        public string LatestStatusCode { get; set; }

        public string LatestStatus { get; set; }

        public int? LatestOperationId { get; set; }

        public bool Running { get; set; }

        public bool Scheduled { get; set; }

        public bool Active { get; set; }

        public DateTime? LastExecutationDate { get; set; }
        public DateTime? NextExecutationDate { get; set; }

        public IEnumerable<JobCounterInfo> Counters { get; set; }
    }
}