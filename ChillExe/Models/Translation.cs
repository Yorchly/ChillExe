using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ChillExe.Models
{
    public class Translation
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }

    public class Translations
    {
        [XmlElement("Translation")]
        public List<Translation> TranslationList { get; set; }
    }
}
