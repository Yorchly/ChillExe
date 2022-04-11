using System;
using System.Collections.Generic;
using System.Text;

namespace ChillExe.Localization
{
    public interface IStringLocalizer
    {
        public string GetTranslation(string id, string defaultValue = "");
    }
}
