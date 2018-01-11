using System.Collections.Generic;

namespace Connector.Tasks.Tracker
{
    public interface ITracker : IEnumerable<JobTrack>
    {
        List<JobTrack> List { get; set; }
        void Add(JobTrack track);
    }
}