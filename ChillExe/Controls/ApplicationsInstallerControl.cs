using ChillExe.Models;
using ChillExe.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChillExe.Controls
{
    public partial class ApplicationsInstallerControl : UserControl
    {
        #region Fields
        private readonly Regex cellStringValueRegex = new Regex(@"^http[s]?\:\/\/");
        private readonly Regex appExecutableName = new Regex(@"[\w\d\-\\_\.]+\.(exe|msi)");
        private const string ERROR_IN_URL = "Text specified is not a http/https";
        private const string ERROR_WITH_EXECUTABLE = "Exe/msi cannot be obtained from url added";
        // TODO -> Change for current downloadAndInstallPath
        //private string downloadAndInstallPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Temp");
        private string downloadAndInstallPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly XmlRepositoryManager<ApplicationsInformation> xmlRepository;
        private List<ApplicationInformation> applicationInformationList;
        #endregion

        #region Constructor
        public ApplicationsInstallerControl()
        {
            xmlRepository = new XmlRepositoryManager<ApplicationsInformation>() 
            { 
                Filename = Path.Join(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "applications_info.xml") 
            };
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
            applicationInformationList = xmlRepository.ReadInfoFromXml()?.ApplicationsInfo;

            if (applicationInformationList == null)
                return;

            foreach(ApplicationInformation info in applicationInformationList)
                applicationInfoGridView.Rows.Add(info.Url, info.LastUpdate);
        }

        private (bool isSaved, string resultMessage) SaveInfoFromList()
        {
            if (applicationInfoGridView.Rows.Count <= 0)
                return (false, "List of URLs is empty.");

            applicationInformationList.Clear();

            foreach (DataGridViewRow row in applicationInfoGridView.Rows)
            {
                if (row.Cells[0].Value == null)
                    continue;

                var urlValue = row.Cells[0].Value.ToString();
                var lastUpdate = DateTime.Parse(row.Cells[1].Value.ToString());

                if (!cellStringValueRegex.IsMatch(urlValue))
                {
                    row.ErrorText = ERROR_IN_URL;
                    return (false, "All url have to be valid (include http or https) before you can save.");
                }
                else if(!appExecutableName.IsMatch(urlValue))
                {
                    row.ErrorText = ERROR_WITH_EXECUTABLE;
                    return (false, "Not all url added to list have an exe/msi");
                }
                else
                    applicationInformationList.Add(
                        new ApplicationInformation() { 
                            Url = urlValue, 
                            LastUpdate = lastUpdate,
                            Filename = Path.Combine(downloadAndInstallPath, appExecutableName.Match(urlValue).Value)
                        }
                    );
            }

            if (xmlRepository.SaveInfoInXml(new ApplicationsInformation { ApplicationsInfo = applicationInformationList }))
                return (true, "Info saved successfully.");
            else
                return (false, "Error saving information in XML.");
        }
        #endregion Methods

        #region Events
        private void SaveButton_Click(object sender, EventArgs e)
        {
            (bool isSaved, string resultMessage) = SaveInfoFromList();

            if (isSaved)
                MessageBox.Show(resultMessage);
            else
                MessageBox.Show(resultMessage, "ERROR", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, 
                    false);
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
            if (applicationInfoGridView.Rows.Count <= 0)
                return;

            // Ensuring that information in list is saved
            (bool isSaved, string resultMessage) = SaveInfoFromList();

            if(!isSaved)
            {
                MessageBox.Show(resultMessage, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly,
                    false);
                return;
            }

            downloadButton.Enabled = false;

            downloadAndInstallControl1.Visible = true;
            downloadAndInstallControl1.DownloadAndInstall(applicationInformationList);
            downloadAndInstallControl1.Visible = false;

            downloadButton.Enabled = true;
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

            if (!appExecutableName.IsMatch(urlValue))
                applicationInfoGridView.Rows[e.RowIndex].ErrorText = ERROR_WITH_EXECUTABLE;
            else
                applicationInfoGridView.Rows[e.RowIndex].ErrorText = "";

            // Setting value in Last Update column
            currentRowCells[1].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        #endregion Events
    }
}
