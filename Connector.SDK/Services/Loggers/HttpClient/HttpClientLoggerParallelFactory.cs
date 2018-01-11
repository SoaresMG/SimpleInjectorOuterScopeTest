using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Net;

namespace Connector.SDK.Services.Loggers.HttpClient
{
    public class HttpClientLoggerParallelFactory<T> : IHttpClientLogger
        where T : class, IHttpClientLogger
    {
        readonly Container container;

        public HttpClientLoggerParallelFactory(Container container)
        {
            this.container = container;
        }

        private IHttpClientLogger GetInstance() => container.GetInstance<T>();

        public void Insert(
                string Url,
                string RequestInfo,
                string RequestData,
                string ResponseInfo,
                string ResponseData,
                HttpStatusCode StatusCode,
                string ReasonPhrase
            )
        {
            using (AsyncScopedLifestyle.BeginScope(container))
                GetInstance().Insert(Url, RequestInfo, RequestData, ResponseInfo, ResponseData, StatusCode, ReasonPhrase);
        }
    }
}