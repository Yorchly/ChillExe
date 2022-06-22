using ChillExe.Forms.MessageBox;
using System;
using System.ComponentModel;

namespace ChillExe.Helpers
{
    public interface IMessageBoxHelper
    {
        public void ShowIconMessageBoxForm(
            string messageBoxTitle, 
            string messageBoxText, 
            MessageBoxFormIcon icon
        );

        public void ShowLoadingFormAndExecutingActionInBackground(
            string loadingFormText, 
            Action<object, DoWorkEventArgs> actionToDoWhileLoadingFormIsShown
        );

        public bool ShowCheckboxFormAndGetIfItsChecked(
            string checkboxFormText, 
            string checkboxFormTitle = "", 
            string dontShowAgainText = ""
        );

        public void ShowTextboxForm(string textboxText, string formTitle = "");
    }
}
