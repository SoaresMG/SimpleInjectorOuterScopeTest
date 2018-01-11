using Connector.SDK.Services.Loggers.Exceptions;
using System.Web.Http.ExceptionHandling;

namespace Connector.SDK.Filters.Exceptions
{
    public sealed class CustomExceptionLogger : ExceptionLogger
    {
        readonly ILogger logger;

        public CustomExceptionLogger(ILogger logger)
        {
            this.logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            logger.Insert(context.Exception, context.RequestContext.RouteData);
            base.Log(context);
        }
    }
}