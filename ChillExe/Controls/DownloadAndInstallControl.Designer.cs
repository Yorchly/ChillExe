
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
            this.downloadInfoGridView = new System.Windows.Forms.DataGridView();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.downloadInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadInfoGridView
            // 
            this.downloadInfoGridView.AllowUserToAddRows = false;
            this.downloadInfoGridView.AllowUserToDeleteRows = false;
            this.downloadInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.downloadInfoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filename,
            this.Status});
            this.downloadInfoGridView.Location = new System.Drawing.Point(0, 0);
            this.downloadInfoGridView.MultiSelect = false;
            this.downloadInfoGridView.Name = "downloadInfoGridView";
            this.downloadInfoGridView.ReadOnly = true;
            this.downloadInfoGridView.RowHeadersWidth = 50;
            this.downloadInfoGridView.RowTemplate.Height = 25;
            this.downloadInfoGridView.Size = new System.Drawing.Size(342, 238);
            this.downloadInfoGridView.TabIndex = 0;
            // 
            // Filename
            // 
            this.Filename.HeaderText = "Filename";
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            this.Filename.Width = 190;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // DownloadAndInstallControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.downloadInfoGridView);
            this.Name = "DownloadAndInstallControl";
            this.Size = new System.Drawing.Size(342, 238);
            ((System.ComponentModel.ISupportInitialize)(this.downloadInfoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView downloadInfoGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
