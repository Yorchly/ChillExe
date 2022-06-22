using ChillExe.Logger;
using ChillExe.Models.Xml;
using ChillExe.Utils;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChillExe.Helpers
{
    public class XmlHelper<T> : IXmlHelper<T>
    {
        public IXmlFile XmlFilePath 
        { 
            get => xmlFilePath;
        }

        private readonly ICustomLogger logger;
        private readonly IXmlFile xmlFilePath;
        private readonly IXmlUtils xmlUtils;
        private string filenameCopyFullPath;

        public XmlHelper(ICustomLogger logger, IXmlFile xmlFilePath, IXmlUtils xmlUtils)
        {
            this.logger = logger;
            this.xmlUtils = xmlUtils;

            CheckXmlFilename(xmlFilePath.FilenameFullPath);
            CheckXsdFilename(xmlFilePath.XsdFilenameFullPath);

            this.xmlFilePath = xmlFilePath;
            SetCopyFilename();
        }

        private void CheckXmlFilename(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                string wrongFilename = "Error with path specified for xml file. Is null or empty.";

                logger.WriteLine(wrongFilename, LogLevel.ERROR);
                throw new ArgumentException(wrongFilename);
            }
        }

        private void CheckXsdFilename(string xsdFilename)
        {
            if (string.IsNullOrEmpty(xsdFilename))
            {
                string wrongFilename = "Error with path specified for xsd file. Is null or empty.";

                logger.WriteLine(wrongFilename, LogLevel.ERROR);
                throw new ArgumentException(wrongFilename);
            }
            else if(!File.Exists(xsdFilename))
            {
                string errorWithXsd =
                    $"Error at XmlHelper constructor. Xsd in path {xsdFilename} not found.";

                logger.WriteLine(errorWithXsd, LogLevel.ERROR);
                throw new FileNotFoundException(errorWithXsd);
            }
        }

        private void SetCopyFilename()
        {
            filenameCopyFullPath = Path.Combine(
                Path.GetDirectoryName(this.xmlFilePath.FilenameFullPath),
                Path.GetFileNameWithoutExtension(xmlFilePath.FilenameFullPath) + "-copy.xml"
            );
        }

        public T Get()
        {
            CheckAndCreateXmlFile(XmlFilePath.FilenameFullPath);

            if (!xmlUtils.IsXmlValid(XmlFilePath.FilenameFullPath, XmlFilePath.XsdFilenameFullPath))
                return default;

            FileStream fileStream = new FileStream(XmlFilePath.FilenameFullPath, FileMode.Open);
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var deserializedInfo = (T)serializer.Deserialize(fileStream);

                return deserializedInfo;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in XmlHelper.Get() -> '{ex.Message}'", LogLevel.ERROR);
                return default;
            }
            finally
            {
                fileStream.Close();
            }
        }

        private void CheckAndCreateXmlFile(string filename)
        {
            if (!File.Exists(filename))
            {
                try
                {
                    FileStream fileStream = File.Create(filename);
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    logger.WriteLine(
                        $"Error in XmlHelper.CheckAndCreateXmlFile -> {ex.Message}", LogLevel.ERROR
                    );

                    throw;
                }

            }
        }

        public bool Write(T element)
        {
            CheckAndCreateXmlFile(filenameCopyFullPath);
            CheckAndCreateXmlFile(XmlFilePath.FilenameFullPath);

            var writer = new StreamWriter(filenameCopyFullPath);
            bool isSaved = false;
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(writer, element);

                writer.Close();

                if (xmlUtils.IsXmlValid(filenameCopyFullPath, XmlFilePath.XsdFilenameFullPath))
                {
                    File.Copy(filenameCopyFullPath, XmlFilePath.FilenameFullPath, overwrite: true);
                    isSaved = true;
                }

                File.Delete(filenameCopyFullPath);

                return isSaved;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in XmlHelper.Save() -> {ex.Message}", LogLevel.ERROR);

                return isSaved;
            }
            finally
            {
                writer.Close();
            }
        }
    }
}
