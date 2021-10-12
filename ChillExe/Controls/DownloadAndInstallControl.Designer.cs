
namespace ChillExe.Controls
{
    partial class DownloadAndInstallControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadAndInstallProgressBar = new System.Windows.Forms.ProgressBar();
            this.DownloadAndInstallLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // downloadAndInstallProgressBar
            // 
            this.downloadAndInstallProgressBar.Location = new System.Drawing.Point(0, 30);
            this.downloadAndInstallProgressBar.Name = "downloadAndInstallProgressBar";
            this.downloadAndInstallProgressBar.Size = new System.Drawing.Size(391, 29);
            this.downloadAndInstallProgressBar.TabIndex = 0;
            // 
            // DownloadAndInstallLabel
            // 
            this.DownloadAndInstallLabel.AutoSize = true;
            this.DownloadAndInstallLabel.Location = new System.Drawing.Point(0, 0);
            this.DownloadAndInstallLabel.Name = "DownloadAndInstallLabel";
            this.DownloadAndInstallLabel.Size = new System.Drawing.Size(201, 20);
            this.DownloadAndInstallLabel.TabIndex = 1;
            this.DownloadAndInstallLabel.Text = "Donwloading and installing...";
            // 
            // DownloadAndInstallControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DownloadAndInstallLabel);
            this.Controls.Add(this.downloadAndInstallProgressBar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DownloadAndInstallControl";
            this.Size = new System.Drawing.Size(391, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadAndInstallProgressBar;
        private System.Windows.Forms.Label DownloadAndInstallLabel;
    }
}
