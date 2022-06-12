using ChillExe.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChillExe.Forms
{
    public partial class Main
    {
        private const int UrlCellIndex = 0;
        private const int LastUpdateCellIndex = 1;
        private const int IsDownloadedCellIndex = 2;
        private const int IsInstalledCellIndex = 3;
        private const string UrlColumnName = "UrlColumn";
        private readonly Regex validUrlRegex = new Regex(@"^http[s]?\:\/\/.+(?:[Dd]ownload|\.(exe|msi)$)");
        private bool isColumnUrlValueValid = true;

        public void LoadAppsInGridView()
        {
            foreach (App app in apps)
            {
                int rowIndex = appsGridView.Rows.Add(
                    app.Url, 
                    app.LastUpdate,
                    GetYesNoTranslateStringFromBoolean(app.IsDownloaded),
                    GetYesNoTranslateStringFromBoolean(app.IsInstalled)
                );
                appsGridView.Rows[rowIndex].Tag = app;
            }
        }

        private string GetYesNoTranslateStringFromBoolean(bool value) =>
            value ? stringLocalizer.GetTranslation("YesButton", "Yes") : stringLocalizer.GetTranslation("NoButton", "No");

        private void appsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (appsGridView.Columns[e.ColumnIndex].Name != UrlColumnName ||
                !isColumnUrlValueValid)
                return;

            DataGridViewRow currentRow = appsGridView.Rows[e.RowIndex];

            currentRow.Cells[LastUpdateCellIndex].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            if (currentRow.Tag == null)
            {
                App app = CreateAppInstanceFromRowData(currentRow);

                currentRow.Tag = app;
                apps.Add(app);

                currentRow.Cells[IsDownloadedCellIndex].Value = GetYesNoTranslateStringFromBoolean(app.IsDownloaded);
                currentRow.Cells[IsInstalledCellIndex].Value = GetYesNoTranslateStringFromBoolean(app.IsInstalled);
            }
            else
            {
                var appFromTag = (App)currentRow.Tag;
                App appFromRow = CreateAppInstanceFromRowData(currentRow);

                appFromTag.Filename = appFromRow.Filename;
                appFromTag.Url = appFromRow.Url;
                appFromTag.LastUpdate = appFromRow.LastUpdate;
            }
        }

        private App CreateAppInstanceFromRowData(DataGridViewRow row)
        {
            return new App
            {
                Filename = GetFilename(),
                Url = row.Cells[UrlCellIndex].Value.ToString(),
                LastUpdate = row.Cells[LastUpdateCellIndex].Value.ToString(),
                IsDownloaded = GetBoolValueFromYesNoString(row.Cells[IsDownloadedCellIndex].Value?.ToString()),
                IsInstalled = GetBoolValueFromYesNoString(row.Cells[IsInstalledCellIndex].Value?.ToString())
            };
        }

        private string GetFilename() =>
            "App_" + Guid.NewGuid().ToString() + ".exe";

        private bool GetBoolValueFromYesNoString(string yesNoValue) =>
            !string.IsNullOrEmpty(yesNoValue) && stringLocalizer.GetTranslation("YesButton", "Yes") == yesNoValue;

        private void appsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (appsGridView.Columns[e.ColumnIndex].Name != UrlColumnName)
                return;

            if (!validUrlRegex.IsMatch(e.FormattedValue.ToString()))
            {
                appsGridView.Rows[e.RowIndex].ErrorText =
                    stringLocalizer.GetTranslation(
                        "UrlNotValid",
                        "Url must contains http/s at the beginning and .exe/.msi at the end. E.g. https//test.com/App.exe"
                    );
                isColumnUrlValueValid = false;
            }
            else
            {
                isColumnUrlValueValid = true;
                appsGridView.Rows[e.RowIndex].ErrorText = "";
            }
        }

        private void appsGridView_Leave(object sender, EventArgs e)
        {
            appHelper.SaveApps(apps);
            ChangeLastSavedTime();
        }

        private void ChangeLastSavedTime()
        {
            lastSaveLabel.Text =
                stringLocalizer.GetTranslation(
                    "LastSavedChanges",
                    "Last changes saved at {0}",
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
                );
        }

        private void appsGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (appsGridView.Rows.Count == 0 || appsGridView.Rows[e.RowIndex].Tag == null)
                return;

            var app = (App)appsGridView.Rows[e.RowIndex].Tag;

            apps.Remove(app);
        }

        private void appsGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow currentRow = appsGridView.Rows[e.RowIndex];

            currentRow.Cells[IsDownloadedCellIndex].Value = GetYesNoTranslateStringFromBoolean(false);
            currentRow.Cells[IsInstalledCellIndex].Value = GetYesNoTranslateStringFromBoolean(false);
        }

        private void RefreshAppsInGridView()
        {
            appsGridView.Rows.Clear();
            LoadAppsInGridView();
        }
    }
}
