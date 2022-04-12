using ChillExe.DAO;
using ChillExe.Localization;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChillExe
{
    public partial class Main : Form
    {
        private IStringLocalizer stringLocalizer;
        private ICustomLogger customLogger;
        private IService<Apps> xmlService;

        public Main(ICustomLogger logger, IService<Apps> xmlService, IStringLocalizer stringLocalizer)
        {
            customLogger = logger;
            this.xmlService = xmlService;
            this.stringLocalizer = stringLocalizer;

            InitializeComponent();
            GetTranslations();
        }

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

        }

        private void spanishDropdownMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void downloadAndInstallButton_Click(object sender, System.EventArgs e)
        {

        }

        private void importButton_Click(object sender, System.EventArgs e)
        {

        }

        private void exportButton_Click(object sender, System.EventArgs e)
        {

        }

        private void cleanListButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
