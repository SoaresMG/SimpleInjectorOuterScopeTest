using System;

namespace Connector.SDK.ViewModels.Jobs
{
    public class ScheduleWeekInfo
    {
        public TimeSpan Time { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
    }
}