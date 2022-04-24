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
        private readonly ICustomLogger logger;
        private readonly XmlHelper<T> xmlHelper;

        public CommonXmlService(ICustomLogger customLogger, IXmlFilePath xmlFilePath)
        {
            logger = customLogger;
            xmlHelper = new XmlHelper<T>(logger, xmlFilePath);
        }

        public virtual T Get() => xmlHelper.Get();


        public virtual bool Save(T tElement) => xmlHelper.Write(tElement);
    }
}
