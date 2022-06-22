using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ChillExe.Models
{
    [Serializable]
    public enum Language
    {
        [XmlEnum("0")]
        Spanish = 0,
        [XmlEnum("1")]
        English = 1
    }

    public class Configuration
    {
        public Language Language { get; set; } = Language.Spanish;
        public bool IsLanguageMessageBoxShown { get; set; } = true;
        public bool IsDownloadAndInstallWarningShown { get; set; } = true;
    }
}
