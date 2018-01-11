using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Connector.SDK.Services.Jobs.Management
{
    using Connector.Common;
    using Connector.SDK.Services.Jobs.TaskFinder;
    using Connector.Tasks;
    using Connector.Tasks.Configuration;
    using Connector.Tasks.Logging;
    using Connector.Tasks.Tracker;

    /// <summary>
    /// This only performs actions on the task side of the job (Connection to runtime)
    /// </summary>
    public class TaskManager : ITaskManager
    {
        readonly ITracker tracker;
        readonly Container container;

        public TaskManager(
                ITracker tracker,
                Container container
            )
        {
            this.tracker = tracker;
            this.container = container;
        }

        public IEnumerable<JobTrack> GetTrack(string Code)
        {
            return this.tracker.Where(x => x.JobCode == Code);
        }

        public IEnumerable<JobTrack> GetTrack(int OperationId)
        {
            return this.tracker.Where(x => x.OperationId == OperationId);
        }

        public void Cancel(int OperationId)
        {
            JobTrack track = this.GetTrack(OperationId).Single();
            track.TokenSource.Cancel();
        }

        public bool IsRunning(int OperationId)
        {
            JobTrack track = this.tracker.SingleOrDefault(x => x.OperationId == OperationId);
            return track != null && track.Running;
        }

        private bool IsCancelledException(Exception e)
            => e is CancelledTaskException || (e.InnerException != null && IsCancelledException(e.InnerException));

        public void RunAsync(int OperationId, string Code, ErpType Erp, bool Forced, Action<TaskStatus> After)
        {
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;

            Task newTask = Task.Run(async () =>
            {
                void setScope()
                {
                    IOperationScope scope = container.GetInstance<IOperationScope>();
                    scope.Provide(OperationId, ct);
                }

                try
                {
                    using (AsyncScopedLifestyle.BeginScope(container))
                    {
                        setScope();

                        ITaskFinder finder = container.GetInstance<ITaskFinder>();
                        (bool IsAsync, object Task) item = finder.Get(Code, Erp);

                        TaskStatus status;
                        if (item.IsAsync)
                            status = await (item.Task as ITaskAsync).Execute();
                        else
                            status = (item.Task as ITask).Execute();
                        After(status);
                    }
                }
                catch (Exception e)
                {
                    /* Use a different scope to ignore all the data inserted before */
                    using (AsyncScopedLifestyle.BeginScope(container))
                    {
                        setScope();

                        ITaskLogger logger = container.GetInstance<ITaskLogger>();

                        await logger.Insert(e, $"Task {Code}");

                        bool cancelled = IsCancelledException(e);
                        After(cancelled ? TaskStatus.Cancelled : TaskStatus.Error);
                    }
                }
            }, ct);

            JobTrack track = new JobTrack()
            {
                JobCode = Code,
                Task = newTask,
                TokenSource = ts,
                OperationId = OperationId
            };

            tracker.Add(track);
        }
    }
}