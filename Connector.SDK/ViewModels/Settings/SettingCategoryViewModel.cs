using System.Collections.Generic;

namespace Connector.SDK.ViewModels.Settings
{
    public class SettingCategoryViewModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public IEnumerable<SettingCategoryViewModel> Children { get; set; }
    }
}