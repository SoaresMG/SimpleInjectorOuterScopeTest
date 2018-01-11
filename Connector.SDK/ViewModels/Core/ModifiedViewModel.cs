using System;

namespace Connector.SDK.ViewModels.Core
{
    public class ModifiedViewModel : CreatedViewModel
    {
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedByUser { get; set; }
    }
}