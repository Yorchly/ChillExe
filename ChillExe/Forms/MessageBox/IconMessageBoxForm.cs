using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChillExe.Forms.MessageBox
{
    public enum MessageBoxFormIcon
    {
        Success,
        Warning,
        Error
    }

    public partial class IconMessageBoxForm : Form
    {
        public IconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBoxFormIcon icon)
        {
            InitializeComponent();
            SetTextInComponents(messageBoxTitle, messageBoxText);
            SetIcon(icon);
        }

        private void SetTextInComponents(string messageBoxTitle, string messageBoxText)
        {
            Text = messageBoxTitle;
            iconMessageBoxFormText.Text = messageBoxText;
        }

        private void SetIcon(MessageBoxFormIcon icon)
        {
            Image iconImage = icon switch
            {
                MessageBoxFormIcon.Success => iconsList.Images[iconsList.Images.IndexOfKey("ok-icon.png")],
                MessageBoxFormIcon.Warning => iconsList.Images[iconsList.Images.IndexOfKey("warning-icon.png")],
                MessageBoxFormIcon.Error => iconsList.Images[iconsList.Images.IndexOfKey("error-icon.png")],
                _ => null
            };

            if (iconImage == null)
                return;

            iconBox.Image = iconImage;
        }

        private void okButton_Click(object sender, EventArgs e) =>
            Visible = false;
    }
}
