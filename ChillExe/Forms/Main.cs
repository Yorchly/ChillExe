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
        private IService<Apps> xmlService;
        private IService<Configuration> configurationService;

        public Main(
            ICustomLogger logger, 
            IService<Apps> xmlService,
            IService<Configuration> configurationService,
            IStringLocalizer stringLocalizer)
        {
            customLogger = logger;
            this.xmlService = xmlService;
            this.stringLocalizer = stringLocalizer;
            this.configurationService = configurationService;

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
