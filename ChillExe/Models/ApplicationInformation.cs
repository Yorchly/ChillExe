using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ChillExe.Models
{
    public enum DownloadStatus
    {
        Downloading = 0,
        Downloaded = 1,
        Error = 2,
    }

    public enum InstallStatus
    {
        Installing = 0,
        Installed = 1,
        Error = 2
    }

    public class ApplicationInformation
    {
        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("lastUpdate")]
        public DateTime LastUpdate { get; set; }
        public DownloadStatus DownloadStatus { get; set; }
        public InstallStatus InstallStatus { get; set; }
        public string Filename { get; set; }
    }

    [XmlRoot("applications")]
    public class ApplicationsInformation
    {
        public List<ApplicationInformation> ApplicationsInfo { get; set; }
    }
}
