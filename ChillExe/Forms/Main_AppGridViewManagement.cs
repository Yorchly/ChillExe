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
        private const int URL_CELL_INDEX = 0;
        private const int LAST_UPDATE_CELL_INDEX = 1;
        private readonly Regex validUrlRegex = new Regex(@"^http[s]?\:\/\/.+\.(exe|msi)$");
        private readonly Regex appExecutableName = new Regex(@"[\w\d\-\\_\.]+\.(exe|msi)");
        private bool isColumnUrlValueValid = true;

        public void LoadAppsInGridView()
        {
            if (appDAO.Apps == null)
                appDAO.Apps = new List<App>();

            foreach (App app in appDAO.Apps)
            {
                int rowIndex = appsGridView.Rows.Add(app.Url, app.LastUpdate);
                appsGridView.Rows[rowIndex].Tag = app;
            }
        }

        private void appsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (appsGridView.Columns[e.ColumnIndex].Name != "UrlColumn" ||
                !isColumnUrlValueValid)
                return;

            DataGridViewRow currentRow = appsGridView.Rows[e.RowIndex];

            currentRow.Cells[LAST_UPDATE_CELL_INDEX].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            if (currentRow.Tag == null)
            {
                App app = GetAppFromRow(currentRow);

                currentRow.Tag = app;
                appDAO.Apps.Add(app);
            }
            else
            {
                var appFromTag = (App)currentRow.Tag;
                App appFromRow = GetAppFromRow(currentRow);

                appFromTag.Filename = appFromRow.Filename;
                appFromTag.Url = appFromRow.Url;
                appFromTag.LastUpdate = appFromRow.LastUpdate;
            }
        }

        private App GetAppFromRow(DataGridViewRow row)
        {
            return new App
            {
                Filename = GetFilenameFromUrl(row.Cells[URL_CELL_INDEX].Value.ToString()),
                Url = row.Cells[URL_CELL_INDEX].Value.ToString(),
                LastUpdate = row.Cells[LAST_UPDATE_CELL_INDEX].Value.ToString()
            };
        }

        private string GetFilenameFromUrl(string url) =>
            appExecutableName.Match(url).ToString();

        private void appsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (appsGridView.Columns[e.ColumnIndex].Name != "UrlColumn")
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
            appDAO.Save();

        private void appsGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (appsGridView.Rows.Count == 0 || appsGridView.Rows[e.RowIndex].Tag == null)
                return;

            var app = (App)appsGridView.Rows[e.RowIndex].Tag;

            appDAO.Apps.Remove(app);
        }
    }
}
