using System;
using System.Web.Http.Routing;

namespace Connector.SDK.Services.Loggers.Exceptions
{
    public class Logger : ILogger
    {
        public void Insert(Exception exception, IHttpRouteData route)
        {
            string controller = route.Values["controller"].ToString() ?? "";
            string action = route.Values["action"].ToString() ?? "";
            this.Insert(exception.ToString(), exception.Message, controller + "." + action);
        }

        public void Insert(Exception exception, string Area)
        {
            this.Insert(exception.ToString(), exception.Message, Area);
        }

        public void Insert(string Message, string Area)
        {
            this.Insert(Message, null, Area);
        }

        public void Insert(string FullMessage, string ShortMessage, string Area)
        {
            // Omitted;
        }
    }
}