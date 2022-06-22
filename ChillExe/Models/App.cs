using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ChillExe.Models
{
    public class App
    {
        public string Url { get; set; }

        public string LastUpdate { get; set; }

        public string Filename { get; set; }

        public bool IsDownloaded { get; set; }

        public bool IsInstalled { get; set; }

        [XmlIgnore]
        public string DownloadedPath { get; set; }
    }

    public class Apps
    {
        [XmlElement("App")]
        public List<App> AppList;
    }
}
