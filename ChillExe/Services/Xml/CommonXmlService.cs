using ChillExe.Logger;
using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChillExe.Services.Xml
{
    public abstract class CommonXmlService<T> : IService<T>
    {
        private string filenameFullPath;
        private string xsdFilename;
        private readonly ICustomLogger logger;
        private string filenameCopyFullPath;

        public CommonXmlService(ICustomLogger customLogger) =>
            logger = customLogger;

        public virtual T Get()
        {
            CheckAndCreateXmlFile(filenameFullPath);

            if (!IsXmlValid(filenameFullPath))
                return default;

            FileStream fileStream = new FileStream(filenameFullPath, FileMode.Open);
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var deserializedInfo = (T)serializer.Deserialize(fileStream);

                return deserializedInfo;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in XmlService.GetAll() -> '{ex.Message}'", LogLevel.ERROR);
                return default;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public virtual bool Save(T tElement)
        {
            CheckAndCreateXmlFile(filenameCopyFullPath);
            CheckAndCreateXmlFile(filenameFullPath);

            var writer = new StreamWriter(filenameCopyFullPath);
            bool isSaved = false;
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(writer, tElement);

                writer.Close();

                if (IsXmlValid(filenameCopyFullPath))
                {
                    File.Copy(filenameCopyFullPath, filenameFullPath, overwrite: true);
                    isSaved = true;
                }

                File.Delete(filenameCopyFullPath);

                return isSaved;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in AppXmlService.Save() -> {ex.Message}", LogLevel.ERROR);

                return isSaved;
            }
            finally
            {
                writer.Close();
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
                        $"Error in AppXmlService.CheckAndCreateXmlFile -> {ex.Message}", LogLevel.ERROR
                    );
                    throw ex;
                }

            }
        }

        private bool IsXmlValid(string filename)
        {
            bool isValid = true;

            try
            {
                var schemas = new XmlSchemaSet();
                schemas.Add("", xsdFilename);

                var document = XDocument.Load(filename);

                document.Validate(
                    schemas,
                    (ValidationEventHandler)((o, validationEventArgs) =>
                    {
                        new CustomLogger().WriteLine(
                            $"Error in AppXmlService.IsXmlValid, validating xml against xsd -> {validationEventArgs.Message}",
                            LogLevel.ERROR
                        );
                        isValid = false;
                    })
                );
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in AppXmlService.IsXmlValid -> {ex.Message}", LogLevel.ERROR);
                isValid = false;
            }

            return isValid;
        }

        protected void SetXmlAndXsdFilenamePath(string xmlFileFullPath, string xsdFileFullPath)
        {
            filenameFullPath = xmlFileFullPath;
            filenameCopyFullPath = Path.Combine(
                Path.GetDirectoryName(filenameFullPath),
                Path.GetFileNameWithoutExtension(filenameFullPath) + "-copy.xml"
            );
            xsdFilename = xsdFileFullPath;
        }
    }
}
