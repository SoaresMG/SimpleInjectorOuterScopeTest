using Connector.Common;
using Connector.Tasks.AX.Service1;
using Connector.Tasks.Configuration;
using Connector.Tasks.ServiceFactory;
using System.Threading.Tasks;

namespace Connector.Tasks.AX
{
    public class CompositeTypeTask : ITaskAsync
    {
        readonly IServiceFactory serviceFactory;
        readonly IOperationScope scope;

        public CompositeTypeTask(
                IServiceFactory serviceFactory,
                IOperationScope scope
            )
        {
            this.serviceFactory = serviceFactory;
            this.scope = scope;
        }

        public string Code => Enums.Jobs.CompositeTypes;

        public ErpType Erp => ErpType.AX;

        public async Task<TaskStatus> Execute()
        {
            var client = serviceFactory.Create<Service1Client>(Code, ServiceNames.AXServices.General);
            var result = await client.GetDataUsingDataContractAsync(new Service1.CompositeType()
            {
                BoolValue = true,
                ExtensionData = null,
                StringValue = "Test"
            });

            return TaskStatus.Success;
        }
    }
}
