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
            if (!configurationService.Get().IsLanguageMessageBoxShown)
                return;

            ShowLanguageMessageBox();
            ChangeLanguageInConfig(Language.English);
        }
        private void ShowLanguageMessageBox()
        {
            InitCheckboxMessageBox();
            checkboxMessageBox.Visible = true;
        }

        private void InitCheckboxMessageBox()
        {
            if (checkboxMessageBox.IsInitialized)
                return;

            checkboxMessageBox.Init(
                configurationService,
                stringLocalizer.GetTranslation("CheckboxMessageBoxTitle", "Important information"),
                stringLocalizer.GetTranslation("CheckboxMessageBoxText", "Language changes will not be applied until you reboot the application"),
                stringLocalizer.GetTranslation("DontShowAgainText", "Don't show again")
            );
        }

        private void ChangeLanguageInConfig(Language language)
        {
            Configuration config = configurationService.Get();
            config.Language = language;

            configurationService.Save(config);
        }

        private void spanishDropdownMenuItem_Click(object sender, System.EventArgs e)
        {
            if (!configurationService.Get().IsLanguageMessageBoxShown)
                return;

            ShowLanguageMessageBox();
            ChangeLanguageInConfig(Language.Spanish);
        }
    }
}
