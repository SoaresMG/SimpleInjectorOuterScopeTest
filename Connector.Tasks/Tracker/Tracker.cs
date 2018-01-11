using System.Collections;
using System.Collections.Generic;

namespace Connector.Tasks.Tracker
{
    public class Tracker : ITracker
    {
        public List<JobTrack> List { get; set; }

        public Tracker()
        {
            this.List = new List<JobTrack>();
        }

        public void Add(JobTrack track)
        {
            this.List.Add(track);
        }

        public IEnumerator<JobTrack> GetEnumerator()
        {
            return this.List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.List.GetEnumerator();
        }
    }
}