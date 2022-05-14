using ChillExe.Models.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Helpers
{
    public interface IXmlHelper<T>
    {
        public IXmlFile XmlFilePath { get; }

        public T Get();

        public bool Write(T element);
    }
}
