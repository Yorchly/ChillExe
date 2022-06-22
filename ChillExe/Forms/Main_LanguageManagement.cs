using ChillExe.Forms.MessageBox;
using ChillExe.Models;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main
    {
        private void GetTranslations()
        {
            languageDropDown.Text = stringLocalizer.GetTranslation("LanguageDropdown", "Language");
            englishDropdownMenuItem.Text = stringLocalizer.GetTranslation("EnglishDropdownMenuItem", "English");
            spanishDropdownMenuItem.Text = stringLocalizer.GetTranslation("SpanishDropdownMenuItem", "Spanish");
            importButton.Text = stringLocalizer.GetTranslation("ImportButton", "Import list");
            exportButton.Text = stringLocalizer.GetTranslation("ExportButton", "Export list");
            downloadAndInstallButton.Text = stringLocalizer.GetTranslation("DownloadAndInstallButton", "Download and install");
            cleanListButton.Text = stringLocalizer.GetTranslation("CleanButton", "Clean list");
            UrlColumn.HeaderText = stringLocalizer.GetTranslation("Url", "Url");
            UrlColumn.ToolTipText = stringLocalizer.GetTranslation("UrlTooltipText", "Url column");
            LastUpdatedColumn.HeaderText = stringLocalizer.GetTranslation("LastUpdated", "Last updated");
            LastUpdatedColumn.ToolTipText = stringLocalizer.GetTranslation("LastUpdatedTooltipText", "Last updated column");
            IsDownloadedColumn.HeaderText = stringLocalizer.GetTranslation("IsDownloadedColumn", "Is downloaded");
            IsInstalledColumn.HeaderText = stringLocalizer.GetTranslation("IsInstalledColumn", "Is installed");
            saveChangesButton.Text = stringLocalizer.GetTranslation("SaveChangesButton", "Save changes");
            lastSaveLabel.Text = stringLocalizer.GetTranslation("LastSavedChanges", "Last changes saved at {0}", "");
        }

        private void englishDropdownMenuItem_Click(object sender, System.EventArgs e)
        {
            if (configuration.Language == Language.English)
                return;

            ChangeLanguageInConfig(Language.English);
            ShowLanguageMessageBox();
        }

        private void ChangeLanguageInConfig(Language language)
        {
            configuration.Language = language;

            configurationHelper.SaveConfiguration(configuration);
        }

        private void ShowLanguageMessageBox()
        {
            if (!configuration.IsLanguageMessageBoxShown)
                return;

            bool isChecked = messageBoxHelper.ShowCheckboxFormAndGetIfItsChecked(
                stringLocalizer.GetTranslation(
                    "CheckboxMessageBoxText", 
                    "Language changes will not be applied until you reboot the application"
                )
            );

            SetIfLanguageCheckboxMessageFormWillBeShownAgain(isChecked);
        }

        private void SetIfLanguageCheckboxMessageFormWillBeShownAgain(bool dontShow)
        {
            if(dontShow)
            {
                configuration.IsLanguageMessageBoxShown = false;
                configurationHelper.SaveConfiguration(configuration);
            }
        }

        private void spanishDropdownMenuItem_Click(object sender, System.EventArgs e)
        {
            if (configuration.Language == Language.Spanish)
                return;

            ChangeLanguageInConfig(Language.Spanish);
            ShowLanguageMessageBox();
        }
    }
}
