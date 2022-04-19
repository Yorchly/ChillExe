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
        private readonly IStringLocalizer stringLocalizer;
        private readonly ICustomLogger customLogger;
        private readonly IAppDAO appDAO;
        private readonly IConfigurationDAO configurationDAO;

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

            InitializeComponent();
            GetTranslations();
            LoadAppsInGridView();
        }
    }
}
