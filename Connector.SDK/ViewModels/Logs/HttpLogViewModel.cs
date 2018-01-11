using Connector.SDK.ViewModels.Core;

namespace Connector.SDK.ViewModels.Logs
{
    public class HttpLogViewModel : CreatedViewModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string RequestInfo { get; set; }

        public string RequestData { get; set; }

        public string ResponseInfo { get; set; }

        public string ResponseData { get; set; }

        public string StatusCode { get; set; }

        public string ReasonPhrase { get; set; }

        public int? OperationId { get; set; }
    }
}