using Connector.Common;
using Connector.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Connector.SDK.Services.Jobs.TaskFinder
{
    public class TaskFinder : ITaskFinder
    {
        readonly IEnumerable<(string Code, ErpType Erp, bool IsAsync, object Task)> tasks;

        public TaskFinder(IEnumerable<ITask> sync, IEnumerable<ITaskAsync> async)
        {
            tasks = sync.Select(x => (x.Code, x.Erp, false, (object)x)).Union(async.Select(x => (x.Code, x.Erp, true, (object)x)));
        }

        public (bool IsAsync, object Task) Get(string Code, ErpType Erp)
        {
            var foundTasks = tasks.Where(x => x.Code == Code && x.Erp == Erp);

            if (!foundTasks.Any())
                throw new Exception($"Task {Code} not found.");

            if (foundTasks.Count() > 1)
                throw new Exception($"Task {Code} has {tasks.Count()} entries.");

            return foundTasks.Select(x => (x.IsAsync, x.Task)).Single();
        }
    }
}