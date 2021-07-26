using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ChillExe.Controls
{
    public partial class ProgramsControl : UserControl
    {
        private readonly Regex cellStringValueRegex = new Regex(@"^http[s]?");
        private readonly string filename = Path.Join(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "applicationsinfo.xml");
        private const string ERROR_IN_URL = "Text specified is not a http/https";

        public ProgramsControl()
        {
            InitializeComponent();
        }

        private void SaveInfoInXml(List<ApplicationInfo> applicationsInfo)
        {
            var serializer = new XmlSerializer(typeof(ApplicationsInformation));
            var writer = new StreamWriter(filename);

            serializer.Serialize(writer, new ApplicationsInformation() { applicationsInfo = applicationsInfo });

            writer.Close();
        }

        private List<ApplicationsInformation> ReadInfoFromXml()
        {
            return new List<ApplicationsInformation>();
        }

        #region Events
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (programsGridView.Rows.Count <= 0)
                return;

            var applicationsInfo = new List<ApplicationInfo>();

            foreach (DataGridViewRow row in programsGridView.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                var urlValue = row.Cells[0].Value.ToString();
                var lastUpdate = DateTime.Parse(row.Cells[1].Value.ToString());

                if (!cellStringValueRegex.IsMatch(urlValue))
                {
                    row.ErrorText = ERROR_IN_URL;
                    MessageBox.Show("All url have to be valid (include http or https) before you can save.",
                        "Error with urls", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly, false);
                    return;
                }
                else
                    applicationsInfo.Add(new ApplicationInfo() { Url = urlValue, LastUpdate = lastUpdate });
            }

            SaveInfoInXml(applicationsInfo);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }

        private void ImportButton_Click(object sender, EventArgs e)
        {

        }

        private void CleanButton_Click(object sender, EventArgs e)
        {
            if (programsGridView.Rows.Count <= 0)
                return;

            programsGridView.Rows.Clear();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
        }

        private void UrlList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (programsGridView.Rows.Count <= 0 || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCellCollection currentRowCells = programsGridView.Rows[e.RowIndex].Cells;
            var urlValue = currentRowCells[0].Value.ToString();

            if (!cellStringValueRegex.IsMatch(urlValue))
                programsGridView.Rows[e.RowIndex].ErrorText = ERROR_IN_URL;
            else
                programsGridView.Rows[e.RowIndex].ErrorText = "";

            // Setting value in Last Update column
            currentRowCells[1].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        #endregion Events
    }
}
