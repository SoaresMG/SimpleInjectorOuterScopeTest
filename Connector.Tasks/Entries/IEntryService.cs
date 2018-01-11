using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connector.Tasks.Entries
{
    public interface IEntryService
    {
        Task<EntryProxy<T>> AddAsync<T>(
                T item,
                bool Editable = false
            ) where T : class;

        Task<EntryProxy<T>> AddAsync<T>(
                T item,
                string Action,
                bool Editable = false
            ) where T : class;

        Task<IEnumerable<EntryProxy<T>>> AddRangeAsync<T>(
                IEnumerable<T> items,
                bool Editable = false
            ) where T : class;

        Task<IEnumerable<EntryProxy<T>>> AddRangeAsync<T>(
                IEnumerable<T> items,
                string Action,
                bool Editable = false
            ) where T : class;

        Task Modify(Guid EntryId, string StatusCode);
        Task Modify<T>(IEnumerable<EntryProxy<T>> Entries, string StatusCode) where T : class;

        IEnumerable<EntryProxy<T>> GetPending<T>(string JobCode) where T : class;
        IEnumerable<EntryProxy<T>> GetPending<T>(string JobCode, string Action) where T : class;
    }
}