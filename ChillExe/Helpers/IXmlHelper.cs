using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Helpers
{
    public interface IXmlHelper<T>
    {
        public T Get();
        public bool Write(T element);
    }
}
