using ChillExe.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ChillExe.Utils
{
    public class XmlUtils : IXmlUtils
    {
        private ICustomLogger logger;

        public XmlUtils(ICustomLogger logger)
        {
            this.logger = logger;
        }

        public bool IsXmlValid(string filename, string xsdFilename)
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
                        logger.WriteLine(
                            $"Error in XmlUtils.IsXmlValid, validating xml against xsd -> {validationEventArgs.Message}",
                            LogLevel.ERROR
                        );
                        isValid = false;
                    })
                );
            }
            catch (Exception ex)
            {
                logger.WriteLine($"Error in XmlUtils.IsXmlValid -> {ex.Message}", LogLevel.ERROR);
                isValid = false;
            }

            return isValid;
        }
    }
}
