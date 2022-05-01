using ChillExe.Forms.MessageBox;

namespace ChillExe.Helpers
{
    public class MessageBoxHelper : IMessageBoxHelper
    {
        public void ShowIconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBoxIcon icon)
        {
            var iconMessageBox = new IconMessageBoxForm(
                messageBoxTitle, messageBoxText, icon
            );

            iconMessageBox.ShowDialog();
            iconMessageBox.Dispose();
        }
    }
}
