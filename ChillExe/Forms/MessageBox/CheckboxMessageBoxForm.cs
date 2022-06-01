using ChillExe.Localization;
using System.Windows.Forms;

namespace ChillExe.Forms.MessageBox
{
    public partial class CheckboxMessageBoxForm : Form
    {
        public CheckboxMessageBoxForm(
            string formTitle,
            string messageBoxText,
            string dontShowAgainText)
        {
            InitializeComponent();
            SetFormComponentsText(formTitle, messageBoxText, dontShowAgainText);
        }

        private void SetFormComponentsText(string formTitle, string messageBoxText, string dontShowAgainText)
        {
            Text = formTitle;
            this.messageBoxText.Text = messageBoxText;
            notShowAgainCheckbox.Text = dontShowAgainText;
        }
    }
}
