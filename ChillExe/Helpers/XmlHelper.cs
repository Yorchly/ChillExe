using ChillExe.Logger;
using ChillExe.Models.Xml;
using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChillExe.Helpers
{
    public class XmlHelper<T> : IXmlHelper<T>
    {
        private ICustomLogger logger;
        private readonly string filenameFullPath;
        private readonly string filenameCopyFullPath;
        private readonly string xsdFilenameFullPath;

        public XmlHelper(ICustomLogger logger, IXmlFilePath xmlFilePath)
        {
            this.logger = logger;

            CheckXmlFilename(xmlFilePath.FilenameFullPath);
            filenameFullPath = xmlFilePath.FilenameFullPath;
            filenameCopyFullPath = Path.Combine(
                Path.GetDirectoryName(filenameFullPath),
                Path.GetFileNameWithoutExtension(filenameFullPath) + "-copy.xml"
            );
            
            CheckXsdFilename(xmlFilePath.XsdFilenameFullPath);
            xsdFilenameFullPath = xmlFilePath.XsdFilenameFullPath;
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

        public T Get()
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

        private bool IsXmlValid(string filename)
        {
            bool isValid = true;

            try
            {
                var schemas = new XmlSchemaSet();
                schemas.Add("", xsdFilenameFullPath);

                var document = XDocument.Load(filename);

                document.Validate(
                    schemas,
                    (ValidationEventHandler)((o, validationEventArgs) =>
                    {
                        logger.WriteLine(
                            $"Error in XmlHelper.IsXmlValid, validating xml against xsd -> {validationEventArgs.Message}",
                            LogLevel.ERROR
                        );
                        isValid = false;
                    })
                );
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in XmlHelper.IsXmlValid -> {ex.Message}", LogLevel.ERROR);
                isValid = false;
            }

            return isValid;
        }

        public bool Write(T element)
        {
            CheckAndCreateXmlFile(filenameCopyFullPath);
            CheckAndCreateXmlFile(filenameFullPath);

            var writer = new StreamWriter(filenameCopyFullPath);
            bool isSaved = false;
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(writer, element);

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
