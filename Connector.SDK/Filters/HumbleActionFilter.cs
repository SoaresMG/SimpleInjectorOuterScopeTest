using SimpleInjector;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Connector.SDK.Filters
{
    public sealed class HumbleActionFilter<TActionFilter> : IActionFilter
        where TActionFilter : class, IActionFilter
    {
        readonly Container container;
        public HumbleActionFilter(Container container) { this.container = container; }

        public bool AllowMultiple => container.GetInstance<TActionFilter>().AllowMultiple;

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
            => container.GetInstance<TActionFilter>().ExecuteActionFilterAsync(actionContext, cancellationToken, continuation);
    }
}