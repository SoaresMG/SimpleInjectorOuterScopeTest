using System;

namespace Connector.Tasks.Entries
{
    public class EntryProxy<T>
        where T : class
    {
        public Guid EntryId { get; set; }

        public T Object { get; set; }

        public EntryProxy() { }

        public EntryProxy(Guid EntryId, T Object)
        {
            this.EntryId = EntryId;
            this.Object = Object;
        }

        public static implicit operator T(EntryProxy<T> proxy) => proxy.Object;
    }
}