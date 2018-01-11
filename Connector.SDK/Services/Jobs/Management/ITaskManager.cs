using Connector.Common;
using Connector.Tasks;
using Connector.Tasks.Tracker;
using System;
using System.Collections.Generic;

namespace Connector.SDK.Services.Jobs.Management
{
    public interface ITaskManager
    {
        IEnumerable<JobTrack> GetTrack(string Code);
        void RunAsync(int OperationId, string Code, ErpType Erp, bool Forced, Action<TaskStatus> After);
        bool IsRunning(int OperationId);
        void Cancel(int OperationId);
    }
}