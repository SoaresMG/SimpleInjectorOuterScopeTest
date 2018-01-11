using Connector.Tasks.Configuration;
using Connector.Tasks.Entries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connector.SDK.Services.Jobs.Operations.Entries
{
    public class EntryService : IEntryService
    {
        readonly IOperationScope scope;

        public EntryService(
                IOperationScope scope
            )
        {
            this.scope = scope;
        }

        public async Task<EntryProxy<T>> AddAsync<T>(T item, string Action, bool Editable = false)
            where T : class
        {
            if (item == null)
                throw new ArgumentNullException("item");

            // Omitted; Use IOperationScope here
            return await Task.FromResult(new EntryProxy<T>(Guid.Empty, item));
        }

        public async Task<EntryProxy<T>> AddAsync<T>(T item, bool Editable = false)
            where T : class
            => await AddAsync(item, null, Editable);

        public async Task<IEnumerable<EntryProxy<T>>> AddRangeAsync<T>(IEnumerable<T> items, string Action, bool Editable = false)
            where T : class
        {
            List<EntryProxy<T>> list = new List<EntryProxy<T>>();
            foreach (T item in items)
                list.Add(await AddAsync(item, Action, Editable));
            return list;
        }

        public async Task<IEnumerable<EntryProxy<T>>> AddRangeAsync<T>(IEnumerable<T> items, bool Editable = false)
            where T : class
            => await AddRangeAsync(items, null, Editable);

        private async Task ModifyAndTrySave(Guid EntryId, string StatusCode, bool Save)
        {
            // Omitted; Use IOperationScope here
            await Task.FromResult(0);
        }

        public async Task Modify(Guid EntryId, string StatusCode)
        {
            await ModifyAndTrySave(EntryId, StatusCode, true);
        }

        public async Task Modify<T>(IEnumerable<EntryProxy<T>> Entries, string StatusCode)
            where T : class
        {
            // Omitted; Use IOperationScope here
            await Task.FromResult(0);
        }

        public IEnumerable<EntryProxy<T>> GetPending<T>(string JobCode, string Action)
        where T : class
        {
            return new List<EntryProxy<T>>();
        }

        public IEnumerable<EntryProxy<T>> GetPending<T>(string JobCode)
            where T : class
            => GetPending<T>(JobCode, null);
    }
}