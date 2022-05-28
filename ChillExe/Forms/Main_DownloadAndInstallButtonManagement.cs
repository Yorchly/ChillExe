using System.ComponentModel;
using System.Threading;

namespace ChillExe.Forms
{
    public partial class Main
    {
        private void downloadAndInstallButton_Click(object sender, System.EventArgs e)
        {
            messageBoxHelper.ShowLoadingFormAndExecutingActionInBackground(
                stringLocalizer.GetTranslation("DownloadingApps", "Downloading apps..."),
                DownloadApps
            );
            messageBoxHelper.ShowLoadingFormAndExecutingActionInBackground(
                stringLocalizer.GetTranslation("InstallingApps", "Installing apps..."),
                InstallApps
            );
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
    }
}
