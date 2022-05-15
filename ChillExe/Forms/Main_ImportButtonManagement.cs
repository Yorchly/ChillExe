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

            if (importFileDialog.ShowDialog() != DialogResult.OK)
                return;

            if (!IsImportedFilenameCorrect(importFileDialog.FileName))
            {
                messageBoxHelper.ShowIconMessageBoxForm(
                    stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                    stringLocalizer.GetTranslation(
                        "InvalidImportedFileName", 
                        "Filename is not valid. Name must be {0}.", 
                        Path.GetFileName(appXmlHelper.XmlFilePath.FilenameFullPath)
                    ),
                    MessageBox.MessageBoxIcon.Error
                );

                return;
            }

            if (!IsImportedFilenameContentValid(importFileDialog.FileName))
            {
                messageBoxHelper.ShowIconMessageBoxForm(
                    stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                    stringLocalizer.GetTranslation("NotValidFileImported", "File imported is not valid."),
                    MessageBox.MessageBoxIcon.Error
                );
                return;
            }

            File.Copy(importFileDialog.FileName, appXmlHelper.XmlFilePath.FilenameFullPath, true);
            LoadAppsFromImportedFile();

            messageBoxHelper.ShowIconMessageBoxForm(
                 stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                 stringLocalizer.GetTranslation("FileImportedSuccessfully", "File imported successfully"),
                 MessageBox.MessageBoxIcon.Success
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
            Path.GetFileName(fileName) == Path.GetFileName(appXmlHelper.XmlFilePath.FilenameFullPath);

        private bool IsImportedFilenameContentValid(string fileName) =>
            xmlUtils.IsXmlValid(fileName, appXmlHelper.XmlFilePath.XsdFilenameFullPath);

        private void LoadAppsFromImportedFile()
        {
            CleanApps();
            apps = appHelper.GetApps();
            LoadAppsInGridView();
        }
    }
}
