using ChillExe.DAO;
using ChillExe.Localization;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main : Form
    {
        private IStringLocalizer stringLocalizer;
        private ICustomLogger customLogger;
        private IAppDAO appDAO;
        private IConfigurationDAO configurationDAO;
        private Configuration config;

        public Main(
            ICustomLogger logger, 
            IAppDAO appDAO,
            IConfigurationDAO configurationDAO,
            IStringLocalizer stringLocalizer)
        {
            customLogger = logger;
            this.appDAO = appDAO;
            this.stringLocalizer = stringLocalizer;
            this.configurationDAO = configurationDAO;
            config = this.configurationDAO.Get();

            InitializeComponent();
            GetTranslations();
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
