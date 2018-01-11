using Connector.Common;

namespace Connector.Tasks
{
    public interface ITask
    {
        string Code { get; }

        ErpType Erp { get; }

        TaskStatus Execute();
    }
}