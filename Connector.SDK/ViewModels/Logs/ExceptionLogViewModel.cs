using Connector.SDK.ViewModels.Core;

namespace Connector.SDK.ViewModels.Logs
{
    public class ExceptionLogViewModel : CreatedViewModel
    {
        public int Id { get; set; }

        public string Area { get; set; }

        public string FullMessage { get; set; }

        public string ShortMessage { get; set; }
    }
}