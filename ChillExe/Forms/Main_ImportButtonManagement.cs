using ChillExe.Models.Xml;
using System.IO;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main
    {
        private bool importFileDialogInitialized = false;

        private void importButton_Click(object sender, System.EventArgs e)
        {
            SetTranslationsForImportFileDialog();

            string appFilename = xmlFileHelper.GetXmlFilePath(XmlFileType.App);

            if (importFileDialog.ShowDialog() != DialogResult.OK)
                return;

            if (!IsImportedFilenameCorrect(importFileDialog.FileName))
            {
                messageBoxHelper.ShowIconMessageBoxForm(
                    stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                    stringLocalizer.GetTranslation(
                        "InvalidImportedFileName", 
                        "Filename is not valid. Name must be {0}.", 
                        Path.GetFileName(appFilename)
                    ),
                    MessageBox.MessageBoxFormIcon.Error
                );

                return;
            }

            if (!IsImportedFilenameContentValid(importFileDialog.FileName))
            {
                messageBoxHelper.ShowIconMessageBoxForm(
                    stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                    stringLocalizer.GetTranslation("NotValidFileImported", "File imported is not valid."),
                    MessageBox.MessageBoxFormIcon.Error
                );
                return;
            }

            File.Copy(importFileDialog.FileName, appFilename, true);
            LoadAppsFromImportedFile();

            messageBoxHelper.ShowIconMessageBoxForm(
                 stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                 stringLocalizer.GetTranslation("FileImportedSuccessfully", "File imported successfully"),
                 MessageBox.MessageBoxFormIcon.Success
             );
        }

        private void SetTranslationsForImportFileDialog()
        {
            if (importFileDialogInitialized)
                return;

            importFileDialog.Title =
                stringLocalizer.GetTranslation("ImportFileDialog", "Choose document you want to import");
            importFileDialogInitialized = true;
        }

        private bool IsImportedFilenameCorrect(string fileName) =>
            Path.GetFileName(fileName) == Path.GetFileName(xmlFileHelper.GetXmlFilePath(XmlFileType.App));

        private bool IsImportedFilenameContentValid(string fileName) =>
            xmlUtils.IsXmlValid(fileName, xmlFileHelper.GetXsdFilePath(XmlFileType.App));

        private void LoadAppsFromImportedFile()
        {
            CleanApps();
            apps = appHelper.GetApps();
            LoadAppsInGridView();
        }
    }
}
