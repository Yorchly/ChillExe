using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillExe.Forms
{
    public partial class Main
    {
        /// <summary>
        /// Normally you will click save button when you have done some changes in
        /// the apps' grid. In order to not save the changes twice, this event is empty because
        /// changes will be saved in appsGridView_Leave event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveChangesButton_Click(object sender, System.EventArgs e) { }
    }
}
