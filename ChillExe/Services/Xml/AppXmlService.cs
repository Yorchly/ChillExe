using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChillExe.Services
{
    public class AppXmlService: IAppService
    {
        public string FilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "apps.xml");
        public string FilenameCopyFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "apps-copy.xml");

        private static readonly string xsdFilename =
            Path.Join(AppContext.BaseDirectory, "Services/Xml/app.xsd");
        private readonly CustomLogger logger = new CustomLogger();

        public List<App> Get()
        {
            CheckAndCreateXmlFile(FilenameFullPath);

            if (!IsXmlValid(FilenameFullPath))
                return default;

            FileStream fileStream = new FileStream(FilenameFullPath, FileMode.Open);
            try
            {
                var serializer = new XmlSerializer(typeof(Apps));
                var deserializedInfo = (Apps)serializer.Deserialize(fileStream);

                return deserializedInfo.AppList;
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in AppXmlService.GetAll() -> '{ex.Message}'", LogLevel.ERROR);
                return default;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public bool Save(List<App> apps)
        {
            CheckAndCreateXmlFile(FilenameCopyFullPath);
            CheckAndCreateXmlFile(FilenameFullPath);

            var writer = new StreamWriter(FilenameCopyFullPath);
            bool isSaved = false;
            try
            {
                var serializer = new XmlSerializer(typeof(Apps));

                serializer.Serialize(writer, new Apps() { AppList = apps });

                writer.Close();

                if (IsXmlValid(FilenameCopyFullPath))
                {
                    File.Copy(FilenameCopyFullPath, FilenameFullPath, overwrite: true);
                    isSaved = true;
                }

                File.Delete(FilenameCopyFullPath);

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
                catch(Exception ex)
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
            catch(Exception ex)
            {
                logger.WriteLine($"Error in AppXmlService.IsXmlValid -> {ex.Message}", LogLevel.ERROR);
                isValid = false;
            }
            
            return isValid;
        }
    }
}
