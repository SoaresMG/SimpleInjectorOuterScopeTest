using Connector.Common;
using Connector.SDK.Services.Jobs.Management;
using System.Web.Http;

namespace Connector.Server.Controllers
{
    public class TestController : ApiController
    {
        readonly ITaskManager taskManager;

        public TestController(ITaskManager taskManager)
        {
            this.taskManager = taskManager;
        }

        [HttpGet]
        public IHttpActionResult Run()
        {
            taskManager.RunAsync(1000, Enums.Jobs.CompositeTypes, ErpType.AX, true, (x) => { });
            return Ok();
        }
    }
}
