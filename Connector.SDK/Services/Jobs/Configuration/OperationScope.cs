using Connector.Tasks;
using Connector.Tasks.Configuration;
using System;
using System.Threading;

namespace Connector.SDK.Services.Jobs.Configuration
{
    public class OperationScope : IOperationScope, IDisposable
    {
        public int? OperationId { get; private set; }

        public CancellationToken Token { get; private set; }

        public bool InSync => OperationId != null;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Provide(int OperationId, CancellationToken Token)
        {
            this.OperationId = OperationId;
            this.Token = Token;
        }

        public void TryCancelTask()
        {
            if (Token.IsCancellationRequested)
                throw new CancelledTaskException();
        }
    }
}