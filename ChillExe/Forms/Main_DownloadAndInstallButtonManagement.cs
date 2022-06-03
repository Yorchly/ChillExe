using ChillExe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChillExe.Forms
{
    public partial class Main
    {
        private void downloadAndInstallButton_Click(object sender, System.EventArgs e)
        {
            ShowDownloadAndInstallWarning();
            messageBoxHelper.ShowLoadingFormAndExecutingActionInBackground(
                stringLocalizer.GetTranslation("DownloadingApps", "Downloading apps..."),
                DownloadApps
            );
            messageBoxHelper.ShowLoadingFormAndExecutingActionInBackground(
                stringLocalizer.GetTranslation("InstallingApps", "Installing apps..."),
                InstallApps
            );

            RefreshAppsInGridView();

            ShowNotDownloadedAndNotInstalledApps();
        }

        private void ShowDownloadAndInstallWarning()
        {
            if (!configuration.IsDownloadAndInstallWarningShown)
                return;

            bool isChecked = messageBoxHelper.ShowCheckboxFormAndGetIfItsChecked(
                stringLocalizer.GetTranslation(
                    "DownloadAndInstallWarning", 
                    "Only not downloaded and not installed marked apps will be downloaded an installed."
                )
            );

            ChangeIsWarningShownInConfiguration(isChecked);
        }

        private void ChangeIsWarningShownInConfiguration(bool isChecked)
        {
            if (!isChecked)
                return;

            configuration.IsDownloadAndInstallWarningShown = false;
            configurationHelper.SaveConfiguration(configuration);
        } 

        private void DownloadApps(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
            appDownloader.Download(apps);
        }

        private void InstallApps(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
            appInstaller.Install(apps);
        }

        private void ShowNotDownloadedAndNotInstalledApps()
        {
            List<App> notDownloadedApps = apps.Where(app => !app.IsDownloaded).ToList();
            List<App> notInstalledApps = apps.Where(app => !app.IsInstalled).ToList();

            if (notDownloadedApps.Count == 0 && notInstalledApps.Count == 0)
                return;

            var notDownloadedAndNotInstalledApps = new StringBuilder();

            if(notDownloadedApps.Count > 0)
            {
                notDownloadedAndNotInstalledApps.AppendLine(
                    stringLocalizer.GetTranslation("NotDownloaded", "Not downloaded:") + "\r"
                );
                notDownloadedAndNotInstalledApps.AppendLine(
                    string.Join("\r\n", notDownloadedApps.Select(app => "-" + app.Url))
                );
            }

            if (notInstalledApps.Count > 0)
            {
                notDownloadedAndNotInstalledApps.AppendLine(
                    stringLocalizer.GetTranslation("NotInstalled", "Not installed:") + "\r"
                );
                notDownloadedAndNotInstalledApps.AppendLine(
                    string.Join("\r\n", notInstalledApps.Select(app => "-" + app.Url))
                );
            }

            messageBoxHelper.ShowTextboxForm(
                notDownloadedAndNotInstalledApps.ToString(),
                stringLocalizer.GetTranslation(
                    "NotDownloadedAndNotInstalledApps", "Not installed neither downloaded apps"
                )
            );
        }
    }
}
