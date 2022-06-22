using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Utils
{
    public interface IXmlUtils
    {
        public bool IsXmlValid(string filename, string xsdFilename);
    }
}
