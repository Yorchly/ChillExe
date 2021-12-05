using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ChillExe.Models
{
    public class ApplicationInformation
    {
        public string Url { get; set; }

        public DateTime LastUpdate { get; set; }

        public string Filename { get; set; }
    }

    [XmlRoot("applications")]
    public class ApplicationsInformation
    {
        public List<ApplicationInformation> ApplicationsInfo { get; set; }
    }
}
