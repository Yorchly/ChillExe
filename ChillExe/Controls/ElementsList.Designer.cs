
namespace ChillExe.Controls
{
    partial class ElementsList
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
            this.urlList = new System.Windows.Forms.DataGridView();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.urlList)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(566, 92);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 31);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(566, 149);
            this.exportButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(86, 31);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export list";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(566, 207);
            this.importButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(86, 31);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import list";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(566, 264);
            this.cleanButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(86, 31);
            this.cleanButton.TabIndex = 4;
            this.cleanButton.Text = "Clean list";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.CleanButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(226, 391);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(194, 31);
            this.downloadButton.TabIndex = 5;
            this.downloadButton.Text = "Download and install exes";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // dataGridView1
            // 
            this.urlList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.urlList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Url,
            this.LastUpdate});
            this.urlList.Location = new System.Drawing.Point(17, 31);
            this.urlList.Name = "dataGridView1";
            this.urlList.RowHeadersWidth = 51;
            this.urlList.RowTemplate.Height = 29;
            this.urlList.Size = new System.Drawing.Size(542, 353);
            this.urlList.TabIndex = 8;
            this.urlList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.UrlList_CellValueChanged);
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
            // ElementsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.urlList);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.saveButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ElementsList";
            this.Size = new System.Drawing.Size(679, 439);
            ((System.ComponentModel.ISupportInitialize)(this.urlList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView urlList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
    }
}
