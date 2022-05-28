using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        private const int YesValueIndexInComboBoxColumn = 0;
        private const int NoValueIndexInComboBoxColumn = 1;
        private const string UrlColumnName = "UrlColumn";
        private const string IsDownloadedColumnName = "IsDownloadedColumn";
        private const string IsInstalledColumnName = "IsInstalledColumn";
        private readonly Regex validUrlRegex = new Regex(@"^http[s]?\:\/\/.+\.(exe|msi)$");
        private readonly Regex appExecutableName = new Regex(@"[\w\d\-\\_\.]+\.(exe|msi)");
        private bool isColumnUrlValueValid = true;

        public void LoadAppsInGridView()
        {
            foreach (App app in apps)
            {
                int rowIndex = appsGridView.Rows.Add(
                    app.Url, 
                    app.LastUpdate,
                    GetIsDownloadedColumnValue(app.IsDownloaded),
                    GetIsInstalledColumnValue(app.IsInstalled)
                );
                appsGridView.Rows[rowIndex].Tag = app;
            }
        }

        private string GetIsDownloadedColumnValue(bool isDownloaded) =>
            isDownloaded ? IsDownloadedColumn.Items[YesValueIndexInComboBoxColumn].ToString() : 
            IsDownloadedColumn.Items[NoValueIndexInComboBoxColumn].ToString();

        private string GetIsInstalledColumnValue(bool isInstalled) =>
            isInstalled ? IsInstalledColumn.Items[YesValueIndexInComboBoxColumn].ToString() : 
            IsInstalledColumn.Items[NoValueIndexInComboBoxColumn].ToString();

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
                Filename = GetFilenameFromUrl(row.Cells[UrlCellIndex].Value.ToString()),
                Url = row.Cells[UrlCellIndex].Value.ToString(),
                LastUpdate = row.Cells[LastUpdateCellIndex].Value.ToString(),
                IsDownloaded = GetIsDownloadedValueFromCellValue(row.Cells[IsDownloadedCellIndex].Value.ToString()),
                IsInstalled = GetIsInstalledValueFromCellValue(row.Cells[IsInstalledCellIndex].Value.ToString())
            };
        }

        private string GetFilenameFromUrl(string url) =>
            appExecutableName.Match(url).ToString();

        private bool GetIsDownloadedValueFromCellValue(string isDownloadedStringValue) =>
            IsDownloadedColumn.Items[YesValueIndexInComboBoxColumn].ToString() == isDownloadedStringValue;

        private bool GetIsInstalledValueFromCellValue(string isInstalledStringValue) =>
            IsInstalledColumn.Items[YesValueIndexInComboBoxColumn].ToString() == isInstalledStringValue;

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

        private void appsGridView_Leave(object sender, EventArgs e) =>
            appHelper.SaveApps(apps);

        private void appsGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (appsGridView.Rows.Count == 0 || appsGridView.Rows[e.RowIndex].Tag == null)
                return;

            var app = (App)appsGridView.Rows[e.RowIndex].Tag;

            apps.Remove(app);
        }

        private void appsGridView_CurrentCellDirtyStateChanged(object sender, System.EventArgs e)
        {
            // Triggers CellValueChanged event for ComboBox column change value.
            if (appsGridView.IsCurrentCellDirty)
                appsGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void appsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((appsGridView.Columns[e.ColumnIndex].Name != IsDownloadedColumnName &&
                appsGridView.Columns[e.ColumnIndex].Name != IsInstalledColumnName) || 
                e.RowIndex < 0)
                return;

            DataGridViewRow currentRow = appsGridView.Rows[e.RowIndex];

            if (currentRow.Tag == null)
                return;

            App app = (App)currentRow.Tag;
            app.IsInstalled = GetIsDownloadedValueFromCellValue(
                currentRow.Cells[IsInstalledCellIndex].Value.ToString()
            );
            app.IsDownloaded = GetIsInstalledValueFromCellValue(
                currentRow.Cells[IsDownloadedCellIndex].Value.ToString()
            );
        }

        private void appsGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow currentRow = appsGridView.Rows[e.RowIndex];

            currentRow.Cells[IsDownloadedCellIndex].Value = GetIsDownloadedColumnValue(false);
            currentRow.Cells[IsInstalledCellIndex].Value = GetIsDownloadedColumnValue(false);
        }
    }
}
