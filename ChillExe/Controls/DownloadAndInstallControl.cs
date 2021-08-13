using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChillExe.Controls
{
    public partial class DownloadAndInstallControl : UserControl
    {
        private readonly StringBuilder downloadingErrorText = new StringBuilder();
        public List<ApplicationInformation> ApplicationInformation { get; set; }

        public DownloadAndInstallControl()
        {
            InitializeComponent();
        }

        public void DownloadAndInstall(List<ApplicationInformation> appInfo)
        {
            if (appInfo == null || appInfo.Count == 0)
            {
                MessageBox.Show("There is an error with downloading list.", "Error with list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ApplicationInformation = appInfo;
            downloadInfoGridView.Rows.Clear();
            DownloadQueue(); //Install();
        }

        private void DownloadQueue()
        {
            int newRowIndex = -1;
            foreach (ApplicationInformation appInfo in ApplicationInformation)
            {
                try
                {
                    var webClient = new WebClient();

                    if (File.Exists(appInfo.Filename))
                        File.Delete(appInfo.Filename);

                    appInfo.DownloadStatus = DownloadStatus.Downloading;

                    newRowIndex = downloadInfoGridView.Rows.Add(appInfo.Filename, Enum.GetName(typeof(DownloadStatus), appInfo.DownloadStatus));
                    Refresh();

                    webClient.DownloadFile(appInfo.Url, appInfo.Filename);

                    appInfo.DownloadStatus = DownloadStatus.Downloaded;

                    downloadInfoGridView.Rows[newRowIndex].Cells[1].Value = Enum.GetName(typeof(DownloadStatus), appInfo.DownloadStatus);
                }
                catch (Exception ex)
                {
                    appInfo.DownloadStatus = DownloadStatus.Error;
                    if (newRowIndex != -1)
                        downloadInfoGridView.Rows[newRowIndex].Cells[1].Value = Enum.GetName(typeof(DownloadStatus), appInfo.DownloadStatus);
                    // TODO: logger
                    if (downloadingErrorText.Length == 0)
                        downloadingErrorText.Append("Error downloading: ");
                    downloadingErrorText.Append($"- {appInfo.Filename}");
                }
            }
            // In order to user can see the result.
            Thread.Sleep(1500);
        }

        private void Install()
        {
            //var process = new Process();
            //process.StartInfo.FileName = filename;
            //process.StartInfo.UseShellExecute = true;
            //process.StartInfo.CreateNoWindow = false;
            //// Get higher privileges
            //process.StartInfo.Verb = "runas";
            //process.Start();
            //process.WaitForExit();
        }
    }
}
