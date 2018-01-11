using Connector.Common;
using System.Threading.Tasks;

namespace Connector.Tasks
{
    public interface ITaskAsync
    {
        string Code { get; }

        ErpType Erp { get; }

        Task<TaskStatus> Execute();
    }
}