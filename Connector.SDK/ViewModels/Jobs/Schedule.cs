using Connector.SDK.ViewModels.Core;
using System;
using System.Collections.Generic;

namespace Connector.SDK.ViewModels.Jobs
{
    public class Schedule : BaseViewModel
    {
        public int Id { get; set; }

        public string TypeCode { get; set; }

        public string Type { get; set; }

        public TimeSpan? Time { get; set; }

        public IEnumerable<ScheduleWeekInfo> WeekDefinition { get; set; }

        public IEnumerable<JobInfo> Jobs { get; set; }
    }
}