using ChillExe.Helpers;
using ChillExe.Logger;
using ChillExe.Models.Xml;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChillExe.Services.Xml
{
    public abstract class CommonXmlService<T> : IService<T>
    {
        private readonly IXmlHelper<T> xmlHelper;

        public CommonXmlService(IXmlHelper<T> xmlHelper)
        {
            this.xmlHelper = xmlHelper;
        }

        public virtual T Get() => xmlHelper.Get();


        public virtual bool Save(T tElement) => xmlHelper.Write(tElement);
    }
}
