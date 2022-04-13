using ChillExe.Models;
using ChillExe.Services;
using System.Windows.Forms;

namespace ChillExe.Controls
{
    public partial class CheckboxMessageBox : UserControl
    {
        private IService<Configuration> configurationService;

        public CheckboxMessageBox()
        {
            InitializeComponent();
        }

        private void Init(
            IService<Configuration> config,
            string messageBoxtTitle,
            string messageBoxText,
            string dontShowAgainText)
        {
            this.configurationService = config;
            SetTextInComponents(messageBoxtTitle, messageBoxText, dontShowAgainText);
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
            if (!dontShowAgainCheckbox.Checked)
                return;

            Configuration config = configurationService.Get();
            config.IsLanguageMessageBoxShown = true;
            configurationService.Save(config);
        }
    }
}
