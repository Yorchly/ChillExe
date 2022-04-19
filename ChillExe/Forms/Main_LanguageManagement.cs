using ChillExe.Forms.MessageBox;
using ChillExe.Models;

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
        }

        private void englishDropdownMenuItem_Click(object sender, System.EventArgs e)
        {
            if (configurationDAO.Configuration.Language == Language.English)
                return;

            ChangeLanguageInConfig(Language.English);
            ShowLanguageMessageBox();
        }

        private void ChangeLanguageInConfig(Language language)
        {
            configurationDAO.Configuration.Language = language;

            configurationDAO.Save();
        }

        private void ShowLanguageMessageBox()
        {
            if (!configurationDAO.Configuration.IsLanguageMessageBoxShown)
                return;

            var checkboxMessageBoxForm = new CheckboxMessageBoxForm(
                stringLocalizer,
                stringLocalizer.GetTranslation("ImportantInformation", "Important information"),
                stringLocalizer.GetTranslation("CheckboxMessageBoxText", "Language changes will not be applied until you reboot the application")
            );

            checkboxMessageBoxForm.ShowDialog();
            SetIfLanguageCheckboxMessageFormWillBeShownAgain(
                checkboxMessageBoxForm.notShowAgainCheckbox.Checked
            );
        }

        private void SetIfLanguageCheckboxMessageFormWillBeShownAgain(bool dontShow)
        {
            if(dontShow)
            {
                configurationDAO.Configuration.IsLanguageMessageBoxShown = false;
                configurationDAO.Save();
            }
        }

        private void spanishDropdownMenuItem_Click(object sender, System.EventArgs e)
        {
            if (configurationDAO.Configuration.Language == Language.Spanish)
                return;

            ChangeLanguageInConfig(Language.Spanish);
            ShowLanguageMessageBox();
        }
    }
}
