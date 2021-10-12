using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillExe.Controls
{
    public partial class DownloadAndInstallControl : UserControl
    {
        private readonly StringBuilder downloadErrors = new StringBuilder();
        private readonly StringBuilder installErrors = new StringBuilder();

        public DownloadAndInstallControl()
        {
            InitializeComponent();
        }

        public void DownloadAndInstall(List<ApplicationInformation> appInfoList)
        {
            if (appInfoList == null || appInfoList.Count == 0)
            {
                MessageBox.Show("There is an error with downloading list.", "Error with list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            downloadAndInstallProgressBar.Value = 0;
            downloadAndInstallProgressBar.Minimum = 0;
            downloadAndInstallProgressBar.Maximum = appInfoList.Count;

            foreach(ApplicationInformation appInfo in appInfoList)
            {
                Refresh();
                bool downloaded = Download(appInfo);

                Refresh();
                if (downloaded)
                    Install(appInfo);

                IncreaseProgressBar(downloadAndInstallProgressBar.Value++);
            }

            if (downloadErrors.Length > 0 || installErrors.Length > 0)
                MessageBox.Show(downloadErrors.ToString() + "\n" + installErrors.ToString(), "Errors!");
        }

        private void IncreaseProgressBar(int value) =>
            downloadAndInstallProgressBar.Value = value;

        private bool Download(ApplicationInformation appInfo)
        {
            try
            {
                var webClient = new WebClient();

                if (File.Exists(appInfo.Filename))
                    File.Delete(appInfo.Filename);

                webClient.DownloadFile(new Uri(appInfo.Url), appInfo.Filename);

                return true;
            }
            catch (Exception ex)
            {
                // TODO: logger
                if (downloadErrors.Length == 0)
                    downloadErrors.Append("Error downloading: ");
                downloadErrors.Append($"- {appInfo.Filename} \n");

                return false;
            }
        }

        private void Install(ApplicationInformation appInfo)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = appInfo.Filename;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.CreateNoWindow = false;
                // Get higher privileges
                process.StartInfo.Verb = "runas";
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // TODO: logger
                if (installErrors.Length == 0)
                    installErrors.Append("Error installing: ");
                installErrors.Append($"- {appInfo.Filename} \n");

            }
        }
    }
}
