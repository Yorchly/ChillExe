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
    public partial class ApplicationsInstallerControl : UserControl
    {
        #region Fields
        private readonly Regex cellStringValueRegex = new Regex(@"^http[s]?\:\/\/");
        private readonly string filename = Path.Join(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "applications_info.xml");
        private const string ERROR_IN_URL = "Text specified is not a http/https";
        #endregion

        #region Constructor
        public ApplicationsInstallerControl()
        {
            InitializeComponent();
            Init();
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Initializing data, extracted from xml, in datagridview.
        /// </summary>
        private void Init()
        {
            List<ApplicationInformation> applicationInformationList = ReadInfoFromXml();

            foreach(ApplicationInformation info in applicationInformationList)
                applicationInfoGridView.Rows.Add(info.Url, info.LastUpdate);
        }

        private void SaveInfoInXml(List<ApplicationInformation> applicationsInfo)
        {
            if (applicationInfoGridView.Rows.Count <= 0)
                return;

            try
            {
                var serializer = new XmlSerializer(typeof(ApplicationsInformation));
                var writer = new StreamWriter(filename);

                serializer.Serialize(writer, new ApplicationsInformation() { ApplicationsInfo = applicationsInfo });

                writer.Close();

                MessageBox.Show("Info saved successfully");
            }
            catch (Exception ex)
            {
                // TODO: logger
                throw;
            }
        }

        private List<ApplicationInformation> ReadInfoFromXml()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ApplicationsInformation));
                var fileStream = new FileStream(filename, FileMode.Open);

                var applicationsInformation = (ApplicationsInformation)serializer.Deserialize(fileStream);

                return applicationsInformation.ApplicationsInfo;
            }
            catch(Exception ex)
            {
                // TODO: logger.
                return new List<ApplicationInformation>();
            }
        }
        #endregion Methods

        #region Events
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (applicationInfoGridView.Rows.Count <= 0)
                return;

            var applicationsInfo = new List<ApplicationInformation>();

            foreach (DataGridViewRow row in applicationInfoGridView.Rows)
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
                    applicationsInfo.Add(new ApplicationInformation() { Url = urlValue, LastUpdate = lastUpdate });
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
            if (applicationInfoGridView.Rows.Count <= 0)
                return;

            applicationInfoGridView.Rows.Clear();
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
        }

        private void UrlList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (applicationInfoGridView.Rows.Count <= 0 || e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCellCollection currentRowCells = applicationInfoGridView.Rows[e.RowIndex].Cells;
            var urlValue = currentRowCells[0].Value.ToString();

            if (!cellStringValueRegex.IsMatch(urlValue))
                applicationInfoGridView.Rows[e.RowIndex].ErrorText = ERROR_IN_URL;
            else
                applicationInfoGridView.Rows[e.RowIndex].ErrorText = "";

            // Setting value in Last Update column
            currentRowCells[1].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        #endregion Events
    }
}
