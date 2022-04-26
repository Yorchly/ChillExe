using ChillExe.DAO;
using ChillExe.Helpers;
using ChillExe.Localization;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using ChillExe.Utils;
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
        private readonly IXmlHelper<Apps> appXmlHelper;
        private readonly IXmlUtils xmlUtils;

        public Main(
            ICustomLogger logger, 
            IAppDAO appDAO,
            IConfigurationDAO configurationDAO,
            IStringLocalizer stringLocalizer,
            IXmlHelper<Apps> appXmlHelper,
            IXmlUtils xmlUtils)
        {
            customLogger = logger;
            this.appDAO = appDAO;
            this.stringLocalizer = stringLocalizer;
            this.configurationDAO = configurationDAO;
            this.appXmlHelper = appXmlHelper;
            this.xmlUtils = xmlUtils;

            InitializeComponent();
            GetTranslations();
            LoadAppsInGridView();
        }
    }
}
