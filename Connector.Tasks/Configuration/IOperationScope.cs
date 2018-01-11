using System.Threading;

namespace Connector.Tasks.Configuration
{
    public interface IOperationScope
    {
        bool InSync { get; }

        int? OperationId { get; }

        CancellationToken Token { get; }

        void Provide(int OperationId, CancellationToken Token);

        void TryCancelTask();
    }
}