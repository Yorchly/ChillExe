using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillExe.Forms.MessageBox
{
    public enum MessageBoxIcon
    {
        Success,
        Warning,
        Error
    }

    public partial class IconMessageBoxForm : Form
    {
        public IconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBoxIcon icon)
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

        private void SetIcon(MessageBoxIcon icon)
        {
            Image iconImage = icon switch
            {
                MessageBoxIcon.Success => iconsList.Images[iconsList.Images.IndexOfKey("ok-icon.png")],
                MessageBoxIcon.Warning => iconsList.Images[iconsList.Images.IndexOfKey("warning-icon.png")],
                MessageBoxIcon.Error => iconsList.Images[iconsList.Images.IndexOfKey("error-icon.png")],
                _ => null
            };

            if (iconImage == null)
                return;

            iconMessageBoxFormText.Image = iconImage;
        }

        private void okButton_Click(object sender, EventArgs e) =>
            Visible = false;
    }
}
