using Connector.Common;

namespace Connector.SDK.Services.Jobs.TaskFinder
{
    public interface ITaskFinder
    {
        (bool IsAsync, object Task) Get(string Code, ErpType Erp);
    }
}