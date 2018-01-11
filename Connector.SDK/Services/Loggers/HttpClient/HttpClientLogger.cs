using Connector.Tasks.Configuration;
using System.Net;

namespace Connector.SDK.Services.Loggers.HttpClient
{
    public class HttpClientLogger : IHttpClientLogger
    {
        readonly IOperationScope scope;

        public HttpClientLogger(IOperationScope scope)
        {
            this.scope = scope;
        }

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
            // Omitted; Use OperationScope here
        }
    }
}