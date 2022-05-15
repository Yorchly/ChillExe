﻿using ChillExe.Helpers;
using ChillExe.Localization;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main : Form
    {
        private readonly IStringLocalizer stringLocalizer;
        private readonly IXmlUtils xmlUtils;
        private readonly IMessageBoxHelper messageBoxHelper;
        private readonly IAppHelper appHelper;
        private readonly IConfigurationHelper configurationHelper;
        private readonly IXmlFileHelper xmlFileHelper;
        private readonly Configuration configuration;
        private List<App> apps;

        public Main( 
            IStringLocalizer stringLocalizer,
            IXmlUtils xmlUtils,
            IMessageBoxHelper messageBoxHelper,
            IAppHelper appHelper,
            IConfigurationHelper configurationHelper,
            IXmlFileHelper xmlFileHelper)
        {
            this.stringLocalizer = stringLocalizer;
            this.xmlUtils = xmlUtils;
            this.messageBoxHelper = messageBoxHelper;
            this.appHelper = appHelper;
            this.configurationHelper = configurationHelper;
            this.xmlFileHelper = xmlFileHelper;
            apps = appHelper.GetApps() ?? new List<App>();
            configuration = configurationHelper.GetConfiguration();

            InitializeComponent();
            GetTranslations();
            LoadAppsInGridView();
        }
    }
}
