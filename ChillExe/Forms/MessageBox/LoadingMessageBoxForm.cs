using System.Windows.Forms;

namespace ChillExe.Forms.MessageBox
{
    public partial class LoadingMessageBoxForm : Form
    {
        public LoadingMessageBoxForm()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            loadingMessageBoxFormText.Text = text;
            Refresh();
        }
    }
}
