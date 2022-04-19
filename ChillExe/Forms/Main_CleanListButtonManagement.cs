using ChillExe.Forms.MessageBox;
using System;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main
    {

        private void CleanListButton_Click(object sender, EventArgs e)
        {
            if (ShowYesNoMessageBoxForm() == DialogResult.Yes)
                CleanApps();
        }

        private DialogResult ShowYesNoMessageBoxForm()
        {
            Form yesNoMessageBoxForm = new YesNoMessageBoxForm(
                stringLocalizer.GetTranslation("ImportantInformation", "Important information"),
                stringLocalizer.GetTranslation(
                    "YesNoMessageBoxText",
                    "Are u sure about this? You are going to delete all elements in list."
                ),
                stringLocalizer.GetTranslation("YesButton", "Yes"),
                stringLocalizer.GetTranslation("NoButton", "No")
            );

            DialogResult result = yesNoMessageBoxForm.ShowDialog();

            yesNoMessageBoxForm.Dispose();

            return result;
        }

        private void CleanApps()
        {
            if (appDAO.Apps.Count == 0)
                return;

            appsGridView.Rows.Clear();
            appDAO.Apps.Clear();
        }
    }
}
