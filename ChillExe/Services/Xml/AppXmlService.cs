using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ChillExe
{
    public class AppXmlService: IAppService
    {
        public string FilenameFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "apps.xml");
        public string FilenameCopyFullPath { get; set; } =
            Path.Join(AppContext.BaseDirectory, "apps-copy.xml");

        private static readonly AppXmlService instance = new AppXmlService();
        private static readonly string xsdFilename =
            Path.Join(AppContext.BaseDirectory, "Services/Xml/app.xsd");

        public static AppXmlService Instance { get => instance; }

        private AppXmlService() { }

        public List<App> Get()
        {
            CheckAndCreateXmlFile();

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
                Logger.Instance.WriteLine($"Error in AppXmlService.GetAll() -> '{ex.Message}'", LogLevel.ERROR);
                return default;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public bool Save(List<App> apps)
        {
            CheckAndCreateXmlFile();

            var writer = new StreamWriter(FilenameCopyFullPath);
            try
            {
                var serializer = new XmlSerializer(typeof(Apps));

                serializer.Serialize(writer, new Apps() { AppList = apps });

                writer.Close();

                // ¿Se podría pasar esta lógica a un método aparte?
                if (!IsXmlValid(FilenameCopyFullPath))
                {
                    File.Delete(FilenameCopyFullPath);
                    return false;
                }
                else
                {
                    File.Copy(FilenameCopyFullPath, FilenameFullPath, overwrite: true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLine($"Error in AppXmlService.Save() -> {ex.Message}", LogLevel.ERROR);
                return false;
            }
            finally
            {
                writer.Close();
            }
        }

        private void CheckAndCreateXmlFile()
        {
            if (!File.Exists(FilenameFullPath))
            {
                FileStream fileStream = File.Create(FilenameFullPath);
                fileStream.Close();
            }
        }

        private static bool IsXmlValid(string filename)
        {
            bool isValid = true;

            try
            {
                var schemas = new XmlSchemaSet();
                schemas.Add("", xsdFilename);

                var document = XDocument.Load(filename);

                document.Validate(
                    schemas,
                    (o, validationEventArgs) =>
                    {
                        Logger.Instance.WriteLine(
                            $"Error in AppXmlService.IsXmlValid, validating xml against xsd -> {validationEventArgs.Message}",
                            LogLevel.ERROR
                        );
                        isValid = false;
                    }
                );
            }
            catch(Exception ex)
            {
                Logger.Instance.WriteLine($"Error in AppXmlService.IsXmlValid -> {ex.Message}", LogLevel.ERROR);
                isValid = false;
            }
            
            return isValid;
        }
    }
}
