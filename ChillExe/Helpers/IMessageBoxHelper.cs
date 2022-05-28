using ChillExe.Forms.MessageBox;
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
        public void ShowIconMessageBoxForm(string messageBoxTitle, string messageBoxText, MessageBoxIcon icon);

        public void ShowLoadingFormAndExecutingActionInBackground(string loadingFormText, Action<object, DoWorkEventArgs> actionToDoWhileLoadingFormIsShown);
    }
}
