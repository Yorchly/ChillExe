using ChillExe.Forms.MessageBox;
using ChillExe.Localization;
using ChillExe.Logger;
using System;
using System.ComponentModel;

namespace ChillExe.Helpers
{
    public class MessageBoxHelper : IMessageBoxHelper
    {
        private readonly ICustomLogger logger;
        private readonly IStringLocalizer stringLocalizer;
        private LoadingMessageBoxForm loadingForm;

        public MessageBoxHelper(ICustomLogger logger, IStringLocalizer stringLocalizer)
        {
            this.logger = logger;
            this.stringLocalizer = stringLocalizer;
        }

        public void ShowIconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBoxFormIcon icon)
        {
            using var iconMessageBox = new IconMessageBoxForm(
                messageBoxTitle, messageBoxText, icon
            );

            iconMessageBox.ShowDialog();
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

        public bool ShowCheckboxFormAndGetIfItsChecked(string checkboxFormText, string checkboxFormTitle = "")
        {
            using var checkboxForm = new CheckboxMessageBoxForm(
                stringLocalizer, checkboxFormText, checkboxFormTitle
            );

            checkboxForm.ShowDialog();

            return checkboxForm.notShowAgainCheckbox.Checked;
        }

        public void ShowTextboxForm(string formTitle, string textboxText)
        {
            var textboxForm = new TextboxMessageBoxForm(
                formTitle, textboxText
            );

            textboxForm.ShowDialog();
        }
    }
}
