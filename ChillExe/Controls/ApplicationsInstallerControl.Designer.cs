
namespace ChillExe.Controls
{
    partial class ApplicationsInstallerControl
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
            this.components = new System.ComponentModel.Container();
            this.saveButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.applicationInfoGridView = new System.Windows.Forms.DataGridView();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadAndInstallControl1 = new ChillExe.Controls.DownloadAndInstallControl();
            ((System.ComponentModel.ISupportInitialize)(this.applicationInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(495, 69);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(495, 112);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export list";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(495, 155);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import list";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(495, 198);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(75, 23);
            this.cleanButton.TabIndex = 4;
            this.cleanButton.Text = "Clean list";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(198, 293);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(170, 23);
            this.downloadButton.TabIndex = 5;
            this.downloadButton.Text = "Download and install exes";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // applicationInfoGridView
            // 
            this.applicationInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.applicationInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Url,
            this.LastUpdate});
            this.applicationInfoGridView.Location = new System.Drawing.Point(15, 23);
            this.applicationInfoGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applicationInfoGridView.Name = "applicationInfoGridView";
            this.applicationInfoGridView.RowHeadersWidth = 51;
            this.applicationInfoGridView.RowTemplate.Height = 29;
            this.applicationInfoGridView.Size = new System.Drawing.Size(474, 265);
            this.applicationInfoGridView.TabIndex = 8;
            this.applicationInfoGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.UrlList_CellValueChanged);
            // 
            // Url
            // 
            this.Url.HeaderText = "Url";
            this.Url.MinimumWidth = 6;
            this.Url.Name = "Url";
            this.Url.Width = 300;
            // 
            // LastUpdate
            // 
            this.LastUpdate.HeaderText = "Last Update";
            this.LastUpdate.MinimumWidth = 6;
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.ReadOnly = true;
            this.LastUpdate.Width = 190;
            // 
            // downloadAndInstallControl1
            // 
            this.downloadAndInstallControl1.Location = new System.Drawing.Point(98, 36);
            this.downloadAndInstallControl1.Name = "downloadAndInstallControl1";
            this.downloadAndInstallControl1.Size = new System.Drawing.Size(340, 240);
            this.downloadAndInstallControl1.TabIndex = 9;
            this.downloadAndInstallControl1.Visible = false;
            // 
            // ApplicationsInstallerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.downloadAndInstallControl1);
            this.Controls.Add(this.applicationInfoGridView);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.saveButton);
            this.Name = "ApplicationsInstallerControl";
            this.Size = new System.Drawing.Size(594, 329);
            ((System.ComponentModel.ISupportInitialize)(this.applicationInfoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView applicationInfoGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private DownloadAndInstallControl downloadAndInstallControl1;
    }
}
