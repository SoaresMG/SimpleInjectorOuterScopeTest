using Connector.Tasks.Entries;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connector.SDK.Services.Jobs.Operations.Entries
{
    /// <summary>
    /// Use this proxy to generate a parallel context for database. Which you may savechanges inside this methods and the above will not be saved.
    /// </summary>
    public class EntryServiceParallelFactory<T> : IEntryService
        where T : class, IEntryService
    {
        readonly Container container;

        public EntryServiceParallelFactory(Container container)
        {
            this.container = container;
        }

        private IEntryService GetInstance() => container.GetInstance<T>();

        public async Task<EntryProxy<S>> AddAsync<S>(S item, string Action, bool Editable = false) where S : class
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                return await GetInstance().AddAsync(item, Action, Editable);
        }

        public async Task<EntryProxy<S>> AddAsync<S>(S item, bool Editable = false) where S : class => await AddAsync(item, null, Editable);

        public async Task<IEnumerable<EntryProxy<S>>> AddRangeAsync<S>(IEnumerable<S> items, string Action, bool Editable = false) where S : class
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                return await GetInstance().AddRangeAsync(items, Action, Editable);
        }

        public async Task<IEnumerable<EntryProxy<S>>> AddRangeAsync<S>(IEnumerable<S> items, bool Editable = false) where S : class => await AddRangeAsync(items, null, Editable);

        public IEnumerable<EntryProxy<S>> GetPending<S>(string JobCode, string Action) where S : class
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                return GetInstance().GetPending<S>(JobCode);
        }

        public IEnumerable<EntryProxy<S>> GetPending<S>(string JobCode) where S : class => GetPending<S>(JobCode, null);

        public async Task Modify(Guid EntryId, string StatusCode)
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                await GetInstance().Modify(EntryId, StatusCode);
        }

        public async Task Modify<S>(IEnumerable<EntryProxy<S>> Entries, string StatusCode)
            where S : class
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                await GetInstance().Modify(Entries, StatusCode);
        }
    }
}