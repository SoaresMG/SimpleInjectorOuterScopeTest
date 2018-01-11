namespace Connector.Common
{
    public static class Enums
    {
        public static string System = "System";
        public static object _SyncAreas;

        // Business
        public static class Jobs
        {
            public const string CompositeTypes = "CompositeTypes";
        }

        public static class OperationStatus
        {
            public const string Running = "Running";
            public const string Success = "Success";
            public const string Error = "Error";
            public const string Cancelled = "Cancelled";
            public const string Cancelling = "Cancelling";
        }

        public static class OperationEntryStatus
        {
            public const string Finished = "Finished";
            public const string Error = "Error";
            public const string Pending = "Pending";
        }

        public static class ScheduleTypes
        {
            public const string Hourly = "Hourly";
            public const string Daily = "Daily";
            public const string Weekly = "Weekly";
        }
    }
}
