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

        private void importButton_Click(object sender, System.EventArgs e)
        {
            SetInitialConfigForOpenFileDialog();

            if (importFileDialog.ShowDialog() != DialogResult.OK)
                return;

            if (!IsImportedFilenameCorrect(importFileDialog.FileName))
            {
                ShowIconMessageBoxForm(
                    stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                    string.Format(
                        stringLocalizer.GetTranslation("InvalidImportedFileName", "Filename is not valid."),
                        Path.GetFileName(appXmlHelper.XmlFilePath.FilenameFullPath)
                    ),
                    MessageBox.MessageBoxIcon.Error
                );

                return;
            }

            if (!IsImportedFilenameContentValid(importFileDialog.FileName))
            {
                ShowIconMessageBoxForm(
                    stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                    stringLocalizer.GetTranslation("NotValidFileImported", "File imported is not valid."),
                    MessageBox.MessageBoxIcon.Error
                );
                return;
            }

            File.Copy(importFileDialog.FileName, appXmlHelper.XmlFilePath.FilenameFullPath, true);
            LoadAppsFromImportedFile();

            ShowIconMessageBoxForm(
                stringLocalizer.GetTranslation("ImportantInformation", "Important information."),
                stringLocalizer.GetTranslation("FileImportedSuccessfully", "File imported successfully"),
                MessageBox.MessageBoxIcon.Success
            );
        }

        private void SetInitialConfigForOpenFileDialog()
        {
            if (openFileDialogInitialized)
                return;

            importFileDialog.Title =
                stringLocalizer.GetTranslation("ImportFileDialog", "Choose document you want to import");
            openFileDialogInitialized = true;
        }

        private bool IsImportedFilenameCorrect(string fileName) =>
            Path.GetFileName(fileName) == Path.GetFileName(appXmlHelper.XmlFilePath.FilenameFullPath);

        private void ShowIconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBox.MessageBoxIcon icon)
        {
            var iconMessageBox = new IconMessageBoxForm(
                messageBoxTitle, messageBoxText, icon
            );

            iconMessageBox.ShowDialog();
            iconMessageBox.Dispose();
        }

        private bool IsImportedFilenameContentValid(string fileName) =>
            xmlUtils.IsXmlValid(fileName, appXmlHelper.XmlFilePath.XsdFilenameFullPath);

        private void LoadAppsFromImportedFile()
        {
            CleanApps();
            appDAO.Refresh();
            LoadAppsInGridView();
        }

        private void exportButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
