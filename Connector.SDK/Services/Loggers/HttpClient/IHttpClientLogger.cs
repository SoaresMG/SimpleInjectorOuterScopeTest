using System.Net;

namespace Connector.SDK.Services.Loggers.HttpClient
{
    public interface IHttpClientLogger
    {
        void Insert(
            string Url,
            string RequestInfo,
            string RequestData,
            string ResponseInfo,
            string ResponseData,
            HttpStatusCode StatusCode,
            string ReasonPhrase
        );
    }
}