using ChillExe.Forms.MessageBox;
using ChillExe.Logger;
using System;
using System.ComponentModel;

namespace ChillExe.Helpers
{
    public class MessageBoxHelper : IMessageBoxHelper
    {
        private readonly ICustomLogger logger;
        private LoadingMessageBoxForm loadingForm;

        public MessageBoxHelper(ICustomLogger logger) => this.logger = logger;

        public void ShowIconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBoxFormIcon icon)
        {
            var iconMessageBox = new IconMessageBoxForm(
                messageBoxTitle, messageBoxText, icon
            );

            iconMessageBox.ShowDialog();
            iconMessageBox.Dispose();
        }

        public void ShowLoadingFormAndExecutingActionInBackground(
            string loadingFormText,
            Action<object, DoWorkEventArgs> actionToDoWhileLoadingFormIsShown)
        {
            InitLoadingMessageBoxForm();
            loadingForm.SetText(loadingFormText);

            try
            {
                using var backgroundWorker = new BackgroundWorker();

                // Background worker is needed in order to use a secondary thread to download the apps.
                // Main thread is blocked by loadingForm.
                backgroundWorker.DoWork += actionToDoWhileLoadingFormIsShown.Invoke;
                backgroundWorker.DoWork += CloseLoadingForm;
                backgroundWorker.RunWorkerAsync();

                loadingForm.ShowDialog();
            }
            catch(Exception ex)
            {
                logger.WriteLine(
                    $"Error in MessageBoxHelper.ShowLoadingFormAndExecutingActionInBackground -> {ex.Message}", 
                    LogLevel.ERROR
                );
            }
            finally
            {
                loadingForm.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
            
        }

        private void InitLoadingMessageBoxForm()
        {
            if (loadingForm == null)
                loadingForm = new LoadingMessageBoxForm();
        }

        private void CloseLoadingForm(object sender, DoWorkEventArgs e)
        {
            if (loadingForm != null)
                loadingForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
