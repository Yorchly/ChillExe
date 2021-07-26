﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ChillExe.Models
{
    public class ApplicationInfo
    {
        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("lastUpdate")]
        public DateTime LastUpdate { get; set; }
    }

    [XmlRoot("applications")]
    public class ApplicationsInformation
    {
        public List<ApplicationInfo> applicationsInfo { get; set; }
    }
}
