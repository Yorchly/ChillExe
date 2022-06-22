using ChillExe.Localization;
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
    public partial class TextboxMessageBoxForm : Form
    {
        public TextboxMessageBoxForm(string formTitle, string textboxText)
        {
            InitializeComponent();
            SetTextInComponents(formTitle, textboxText);
        }

        private void SetTextInComponents(string formTitle, string textboxText)
        {
            Text = formTitle;
            textBox.Text = textboxText;
        }
    }
}
