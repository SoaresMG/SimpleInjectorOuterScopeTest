namespace Connector.SDK.ViewModels.Languages
{
    public class LanguageViewModel
    {
        public string Code { get; set; } // ISO Code ex: pt-pt

        public byte[] CultureCode { get; set; } // Exp: 0x0436

        public string ISO639xValue { get; set; } // Exp: AFK

        public string SmallCode { get; set; } // Ex: pt

        public bool Default { get; set; }
    }
}