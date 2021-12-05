using System;
using System.IO;
using System.Xml.Serialization;

namespace ChillExe.Repository
{
    public class XmlRepositoryManager<T>
    {
        public string Filename { get; }

        public XmlRepositoryManager(string filename) 
        {
            if (!File.Exists(filename))
                File.Create(filename);

            Filename = filename;
        }

        public bool SaveInfoInXml(T information)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var writer = new StreamWriter(Filename);

                serializer.Serialize(writer, information);

                writer.Close();

                return true;
            }
            catch (Exception ex)
            {
                // TODO: logger
                return false;
            }
        }

        public T ReadInfoFromXml()
        {
            FileStream fileStream;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                fileStream = new FileStream(Filename, FileMode.Open);

                var information = (T)serializer.Deserialize(fileStream);

                fileStream.Close();

                return information;
            }
            catch (Exception ex)
            {
                // TODO: logger.
                return default;
            }
        }
    }
}
