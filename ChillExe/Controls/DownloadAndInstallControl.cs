using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

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

        public async void DownloadAndInstall(List<ApplicationInformation> appInfoList)
        {
            if (appInfoList == null || appInfoList.Count == 0)
            {
                MessageBox.Show("There is an error with downloading list.", "Error with list", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            downloadErrors.Clear(); installErrors.Clear();

            downloadAndInstallProgressBar.Step = 1;
            downloadAndInstallProgressBar.Minimum = 0;
            downloadAndInstallProgressBar.Maximum = appInfoList.Count;

            var progress = new Progress<int>(value =>
            {
                downloadAndInstallProgressBar.Value = value;
            });

            var appDownloaded = new List<(ApplicationInformation appInfo, bool downloaded)>();
            int count = 1;

            foreach (ApplicationInformation appInfo in appInfoList)
            {
                appDownloaded.Add((appInfo, Download(appInfo)));
                await Task.Run(() => UpdateProgressBar(progress, count));
                count++;
            }

            if (appDownloaded.Exists(tupleElement => tupleElement.downloaded))
            {
                DownloadAndInstallLabel.Text = "Installing...";
                Refresh();
            }

            foreach ((ApplicationInformation appInfo, bool downloaded) in appDownloaded.Where(tupleElement => tupleElement.downloaded))
            {
                await Task.Run(() =>
                {
                    Install(appInfo);
                });
            }

            if (downloadErrors.Length > 0 || installErrors.Length > 0)
            {
                downloadErrors.Append(installErrors);
                MessageBox.Show(downloadErrors.ToString() + "\n" + installErrors.ToString(), "Errors!");
            }
        }

        private static void UpdateProgressBar(IProgress<int> progress, int value) => progress?.Report(value);

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
                    downloadErrors.Append("Error downloading: \n");
                downloadErrors.Append($"- {appInfo.Filename} \n");

                return false;
            }
        }

        private bool Install(ApplicationInformation appInfo)
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

                return true;
            }
            catch (Exception ex)
            {
                // TODO: logger
                if (installErrors.Length == 0)
                    installErrors.Append("Error installing: \n");
                installErrors.Append($"- {appInfo.Filename} \n");

                return false;
            }
        }
    }
}
