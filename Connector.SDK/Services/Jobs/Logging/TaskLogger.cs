using Connector.Tasks.Configuration;
using Connector.Tasks.Entries;
using Connector.Tasks.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connector.SDK.Services.Jobs.Logging
{
    public class TaskLogger : ITaskLogger
    {
        readonly IOperationScope scope;

        public TaskLogger(
                IOperationScope scope
            )
        {
            this.scope = scope;
        }

        public async Task Insert(string Message)
        {
            await __Insert(Message, null, null);
        }

        public async Task Insert<T>(string Message, EntryProxy<T> Entry) where T : class
        {
            await __Insert(Message, null, Entry.EntryId);
        }

        public async Task Insert(Exception exception, string Area)
        {
            await __Insert(exception.ToString(), Area, null);
        }

        public async Task Insert<T>(Exception exception, EntryProxy<T> Entry) where T : class
        {
            await __Insert(exception.ToString(), null, Entry.EntryId);
        }

        public async Task Insert<T>(Exception exception, IEnumerable<EntryProxy<T>> Entries) where T : class
        {

            foreach (EntryProxy<T> entry in Entries)
                await __Insert(exception.ToString(), null, entry.EntryId);
        }

        private async Task __Insert(string Message, string Area, Guid? EntryId)
        {
            // Use operation scope here
            await Task.FromResult(0); // Omitted
        }
    }
}