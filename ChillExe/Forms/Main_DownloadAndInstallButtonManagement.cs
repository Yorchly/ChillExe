using System;
using System.ComponentModel;
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
            //appInstaller.Install(apps);
        }
    }
}
