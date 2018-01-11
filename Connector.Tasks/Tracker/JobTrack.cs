using System.Threading;
using System.Threading.Tasks;

namespace Connector.Tasks.Tracker
{
    public class JobTrack
    {
        public string JobCode { get; set; }

        public Task Task { get; set; }

        public CancellationTokenSource TokenSource { get; set; }

        public int OperationId { get; set; }

        public bool Running
        {
            get
            {
                return Task != null && !Task.IsCanceled && !Task.IsCompleted;
            }
        }
    }
}