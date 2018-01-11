using SimpleInjector;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace Connector.SDK.Filters.Exceptions
{
    public sealed class HumbleExceptionLogger<TActionFilter> : IExceptionLogger
            where TActionFilter : class, IExceptionLogger
    {
        readonly Container container;
        public HumbleExceptionLogger(Container container) { this.container = container; }

        public async Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
            => await container.GetInstance<TActionFilter>().LogAsync(context, cancellationToken);
    }
}