﻿using ChillExe.Forms.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Helpers
{
    public interface IMessageBoxHelper
    {
        public void ShowIconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBoxFormIcon icon);

        public void ShowLoadingFormAndExecutingActionInBackground(string loadingFormText, Action<object, DoWorkEventArgs> actionToDoWhileLoadingFormIsShown);

        public bool ShowCheckboxFormAndGetIfItsChecked(string checkboxFormText, string checkboxFormTitle = "");

        public void ShowTextboxForm(string formTitle, string textboxText);
    }
}
