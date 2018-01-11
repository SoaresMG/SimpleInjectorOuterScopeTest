using System.Collections.Generic;

namespace Connector.SDK.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}