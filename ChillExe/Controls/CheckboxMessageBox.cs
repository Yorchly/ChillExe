using ChillExe.Models;
using ChillExe.Services;
using System.Windows.Forms;

namespace ChillExe.Controls
{
    public partial class CheckboxMessageBox : UserControl
    {
        private IService<Configuration> configurationService;

        public bool IsInitialized { get; set; } = false;

        public CheckboxMessageBox()
        {
            InitializeComponent();
        }

        public void Init(
            IService<Configuration> config,
            string messageBoxtTitle,
            string messageBoxText,
            string dontShowAgainText)
        {
            configurationService = config;
            SetTextInComponents(messageBoxtTitle, messageBoxText, dontShowAgainText);
            IsInitialized = true;
        }

        private void SetTextInComponents(string messageBoxTitle, string messageBoxText, string dontShowAgainText)
        {
            this.messageBoxTitle.Text = messageBoxTitle;
            this.messageBoxText.Text = messageBoxText;
            this.dontShowAgainCheckbox.Text = dontShowAgainText;
        }

        private void toolStripClosebutton_Click(object sender, System.EventArgs e)
        {
            this.Visible = false;
            SetDontShowAgainStatusInConfiguration();
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            this.Visible = false;
            SetDontShowAgainStatusInConfiguration();
        }

        private void SetDontShowAgainStatusInConfiguration()
        {
            Configuration config = configurationService.Get();

            if (!dontShowAgainCheckbox.Checked || !config.IsLanguageMessageBoxShown)
                return;

            config.IsLanguageMessageBoxShown = false;
            configurationService.Save(config);
        }
    }
}
