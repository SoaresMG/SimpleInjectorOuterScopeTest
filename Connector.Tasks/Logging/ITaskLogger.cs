using Connector.Tasks.Entries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connector.Tasks.Logging
{
    public interface ITaskLogger
    {
        Task Insert(string Message);
        Task Insert<T>(string Message, EntryProxy<T> Entry) where T : class;
        Task Insert(Exception exception, string Area);
        Task Insert<T>(Exception exception, EntryProxy<T> Entry) where T : class;
        Task Insert<T>(Exception exception, IEnumerable<EntryProxy<T>> Entries) where T : class;
    }
}