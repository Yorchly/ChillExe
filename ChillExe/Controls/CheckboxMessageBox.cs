using ChillExe.DAO;
using ChillExe.Models;
using ChillExe.Services;
using System.Windows.Forms;

namespace ChillExe.Controls
{
    public partial class CheckboxMessageBox : UserControl
    {
        private IConfigurationDAO configurationDAO;

        public bool IsInitialized { get; set; } = false;

        public CheckboxMessageBox()
        {
            InitializeComponent();
        }

        public void Init(
            IConfigurationDAO configurationDAO,
            string messageBoxtTitle,
            string messageBoxText,
            string dontShowAgainText)
        {
            this.configurationDAO = configurationDAO;
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
            Configuration config = configurationDAO.Get();

            if (!dontShowAgainCheckbox.Checked || !config.IsLanguageMessageBoxShown)
                return;

            config.IsLanguageMessageBoxShown = false;
            configurationDAO.Save();
        }
    }
}
