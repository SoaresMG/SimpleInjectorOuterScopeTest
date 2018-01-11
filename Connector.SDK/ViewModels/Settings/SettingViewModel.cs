using Connector.SDK.ViewModels.Core;

namespace Connector.SDK.ViewModels.Settings
{
    public class SettingViewModel : BaseViewModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Default { get; set; }

        public bool Edit { get; set; }

        public string TypeCode { get; set; }

        public string Type { get; set; }

        public string CategoryCode { get; set; }

        public string Category { get; set; }

        public bool Dynamic { get; set; }

        public string ListConfig { get; set; }

        public bool Encrypted { get; set; }
    }
}