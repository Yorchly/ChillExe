using ChillExe.Models.Xml;
using System.IO;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main
    {
        private bool saveFileDialogInitialized = false;

        private void exportButton_Click(object sender, System.EventArgs e)
        {
            SetTranslationsForExportFileDialog();

            string appFilename = xmlFileHelper.GetXmlFilePath(XmlFileType.App);
            exportFileDialog.FileName = Path.GetFileName(appFilename);

            if (exportFileDialog.ShowDialog() != DialogResult.OK)
                return;
            
            File.Copy(appFilename, exportFileDialog.FileName, true);
            messageBoxHelper.ShowIconMessageBoxForm(
                stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                stringLocalizer.GetTranslation("FileExportedSuccessfully", "The file has been exported successfully."),
                MessageBox.MessageBoxIcon.Success
            );
        }

        private void SetTranslationsForExportFileDialog()
        {
            if (saveFileDialogInitialized)
                return;

            exportFileDialog.Title =
                stringLocalizer.GetTranslation(
                    "ExportFileDialog", "Choose directory where you want to save the list of apps."
                );

            saveFileDialogInitialized = true;
        }
    }
}
