using System;
using System.Web.Http.Routing;

namespace Connector.SDK.Services.Loggers.Exceptions
{
    public interface ILogger
    {
        /// <summary>
        /// Insert exception log with RouteData (Controller + Action)
        /// </summary>
        /// <param name="exception">Exception to be inserted</param>
        /// <param name="route">Controller's route</param>
        void Insert(Exception exception, IHttpRouteData route);

        /// <summary>
        /// Insert exception log with an area
        /// </summary>
        /// <param name="exception">Exception to be inserted</param>
        /// <param name="Area">Area where the error occurred</param>
        void Insert(Exception exception, string Area);

        /// <summary>
        /// Insert a message with an area
        /// </summary>
        /// <param name="FullMessage">Message to be inserted</param>
        /// <param name="ShortMessage">Resumed message to be shown</param>
        /// <param name="Area">Area where the error occurred</param>
        void Insert(string FullMessage, string ShortMessage, string Area);

        /// <summary>
        /// Insert a message with an area
        /// </summary>
        /// <param name="exception">Message to be inserted</param>
        /// <param name="Area">Area where the error occurred</param>
        void Insert(string Message, string Area);
    }
}