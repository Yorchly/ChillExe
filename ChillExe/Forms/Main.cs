using ChillExe.Helpers;
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
        private readonly ICustomLogger customLogger;
        private readonly IXmlHelper<Apps> appXmlHelper;
        private readonly IXmlUtils xmlUtils;
        private readonly IMessageBoxHelper messageBoxHelper;
        private readonly IAppHelper appHelper;
        private readonly IConfigurationHelper configurationHelper;
        private readonly Configuration configuration;
        private List<App> apps;

        public Main(
            ICustomLogger logger, 
            IStringLocalizer stringLocalizer,
            IXmlHelper<Apps> appXmlHelper,
            IXmlUtils xmlUtils,
            IMessageBoxHelper messageBoxHelper,
            IAppHelper appHelper,
            IConfigurationHelper configHelper)
        {
            customLogger = logger;
            this.stringLocalizer = stringLocalizer;
            this.appXmlHelper = appXmlHelper;
            this.xmlUtils = xmlUtils;
            this.messageBoxHelper = messageBoxHelper;
            this.appHelper = appHelper;
            this.configurationHelper = configHelper;
            apps = appHelper.GetApps() ?? new List<App>();
            configuration = configHelper.GetConfiguration();

            InitializeComponent();
            GetTranslations();
            LoadAppsInGridView();
        }
    }
}
