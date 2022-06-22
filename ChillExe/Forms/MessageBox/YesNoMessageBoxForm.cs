using System.Windows.Forms;

namespace ChillExe.Forms.MessageBox
{
    public partial class YesNoMessageBoxForm : Form
    {
        public YesNoMessageBoxForm(
            string formTitle,
            string messageBoxText, 
            string yesButtonText, 
            string noButtonText)
        {
            InitializeComponent();
            SetFormComponentsText(
                formTitle, messageBoxText, yesButtonText, noButtonText
            );
        }

        public void SetFormComponentsText(
            string formTitle, 
            string messageBoxText,
            string yesButtonText,
            string noButtonText)
        {
            Text = formTitle;
            this.messageBoxText.Text = messageBoxText;
            yesButton.Text = yesButtonText;
            noButton.Text = noButtonText;
        }
    }
}
