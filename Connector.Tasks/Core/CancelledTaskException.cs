using System;

namespace Connector.Tasks
{
    [Serializable]
    public class CancelledTaskException : Exception
    {
        public CancelledTaskException() : base("This task was cancelled by the user") { }
    }
}