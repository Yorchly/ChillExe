using ChillExe.Localization;
using System.Windows.Forms;

namespace ChillExe.Forms.MessageBox
{
    public partial class CheckboxMessageBoxForm : Form
    {
        private readonly IStringLocalizer stringLocalizer;

        public CheckboxMessageBoxForm(
            IStringLocalizer stringLocalizer,
            string messageBoxText,
            string formTitle = "")
        {
            this.stringLocalizer = stringLocalizer;

            InitializeComponent();
            SetFormComponentsText(formTitle, messageBoxText);
        }

        private void SetFormComponentsText(string formTitle, string messageBoxText)
        {
            Text = string.IsNullOrEmpty(formTitle) ? 
                stringLocalizer.GetTranslation("ImportantInformation", "Important information") : 
                formTitle;
            this.messageBoxText.Text = messageBoxText;
            notShowAgainCheckbox.Text = stringLocalizer.GetTranslation(
                "DontShowAgainText", "Don't show again"
            );
        }
    }
}
