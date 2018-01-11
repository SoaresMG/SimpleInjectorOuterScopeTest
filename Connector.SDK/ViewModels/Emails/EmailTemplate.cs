using System;
using System.Collections.Generic;

namespace Connector.SDK.ViewModels.Emails
{
    public class EmailTemplate
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Html { get; set; }

        public string TypeCode { get; set; }

        public string Type { get; set; }

        public int? LayoutId { get; set; }

        public string LayoutName { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedByUser { get; set; }

        public string ModifiedByUser { get; set; }

        public string LanguageCode { get; set; }

        public IEnumerable<EmailTemplateKeyword> Keywords { get; set; }
    }
}