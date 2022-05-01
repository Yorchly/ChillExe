using ChillExe.Forms.MessageBox;
using System;
using System.IO;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main
    {
        private bool openFileDialogInitialized = false;
        private bool saveFileDialogInitialized = false;

        #region Import
        private void importButton_Click(object sender, System.EventArgs e)
        {
            SetTranslationsForImportFileDialog();

            if (importFileDialog.ShowDialog() != DialogResult.OK)
                return;

            if (!IsImportedFilenameCorrect(importFileDialog.FileName))
            {
                messageBoxHelper.ShowIconMessageBoxForm(
                    stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                    string.Format(
                        stringLocalizer.GetTranslation("InvalidImportedFileName", "Filename is not valid. Name must be {0}."),
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

           messageBoxHelper. ShowIconMessageBoxForm(
                stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                stringLocalizer.GetTranslation("FileImportedSuccessfully", "File imported successfully"),
                MessageBox.MessageBoxIcon.Success
            );
        }

        private void SetTranslationsForImportFileDialog()
        {
            if (openFileDialogInitialized)
                return;

            importFileDialog.Title =
                stringLocalizer.GetTranslation("ImportFileDialog", "Choose document you want to import");
            openFileDialogInitialized = true;
        }

        private bool IsImportedFilenameCorrect(string fileName) =>
            Path.GetFileName(fileName) == Path.GetFileName(appXmlHelper.XmlFilePath.FilenameFullPath);

        private bool IsImportedFilenameContentValid(string fileName) =>
            xmlUtils.IsXmlValid(fileName, appXmlHelper.XmlFilePath.XsdFilenameFullPath);

        private void LoadAppsFromImportedFile()
        {
            CleanApps();
            appDAO.Refresh();
            LoadAppsInGridView();
        }

        #endregion

        #region Export

        private void exportButton_Click(object sender, System.EventArgs e)
        {
            SetTranslationsForExportFileDialog();
            exportFileDialog.FileName = Path.GetFileName(appXmlHelper.XmlFilePath.FilenameFullPath);

            if (exportFileDialog.ShowDialog() != DialogResult.OK)
                return;
            
            File.Copy(appXmlHelper.XmlFilePath.FilenameFullPath, exportFileDialog.FileName, true);
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

        #endregion
    }
}
