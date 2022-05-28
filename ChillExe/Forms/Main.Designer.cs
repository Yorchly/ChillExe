
namespace ChillExe.Forms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.appsGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.languageDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.spanishDropdownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishDropdownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAndInstallButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.cleanListButton = new System.Windows.Forms.Button();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.UrlColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdatedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDownloadedColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IsInstalledColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.appsGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appsGridView
            // 
            this.appsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UrlColumn,
            this.LastUpdatedColumn,
            this.IsDownloadedColumn,
            this.IsInstalledColumn});
            this.appsGridView.Location = new System.Drawing.Point(10, 28);
            this.appsGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.appsGridView.Name = "appsGridView";
            this.appsGridView.RowHeadersWidth = 51;
            this.appsGridView.RowTemplate.Height = 29;
            this.appsGridView.Size = new System.Drawing.Size(792, 472);
            this.appsGridView.TabIndex = 0;
            this.appsGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.appsGridView_CellEndEdit);
            this.appsGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.appsGridView_CellValidating);
            this.appsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.appsGridView_CellValueChanged);
            this.appsGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.appsGridView_CurrentCellDirtyStateChanged);
            this.appsGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.appsGridView_RowsAdded);
            this.appsGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.appsGridView_RowsRemoved);
            this.appsGridView.Leave += new System.EventHandler(this.appsGridView_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageDropDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1047, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // languageDropDown
            // 
            this.languageDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.languageDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spanishDropdownMenuItem,
            this.englishDropdownMenuItem});
            this.languageDropDown.Image = ((System.Drawing.Image)(resources.GetObject("languageDropDown.Image")));
            this.languageDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.languageDropDown.Name = "languageDropDown";
            this.languageDropDown.Size = new System.Drawing.Size(72, 22);
            this.languageDropDown.Text = "Language";
            // 
            // spanishDropdownMenuItem
            // 
            this.spanishDropdownMenuItem.Name = "spanishDropdownMenuItem";
            this.spanishDropdownMenuItem.Size = new System.Drawing.Size(115, 22);
            this.spanishDropdownMenuItem.Text = "Spanish";
            this.spanishDropdownMenuItem.Click += new System.EventHandler(this.spanishDropdownMenuItem_Click);
            // 
            // englishDropdownMenuItem
            // 
            this.englishDropdownMenuItem.Name = "englishDropdownMenuItem";
            this.englishDropdownMenuItem.Size = new System.Drawing.Size(115, 22);
            this.englishDropdownMenuItem.Text = "English";
            this.englishDropdownMenuItem.Click += new System.EventHandler(this.englishDropdownMenuItem_Click);
            // 
            // downloadAndInstallButton
            // 
            this.downloadAndInstallButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downloadAndInstallButton.Location = new System.Drawing.Point(839, 149);
            this.downloadAndInstallButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downloadAndInstallButton.Name = "downloadAndInstallButton";
            this.downloadAndInstallButton.Size = new System.Drawing.Size(183, 27);
            this.downloadAndInstallButton.TabIndex = 2;
            this.downloadAndInstallButton.Text = "Download and install";
            this.downloadAndInstallButton.UseVisualStyleBackColor = true;
            this.downloadAndInstallButton.Click += new System.EventHandler(this.downloadAndInstallButton_Click);
            // 
            // importButton
            // 
            this.importButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.importButton.Location = new System.Drawing.Point(839, 196);
            this.importButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(183, 27);
            this.importButton.TabIndex = 3;
            this.importButton.Text = "Import list";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exportButton.Location = new System.Drawing.Point(839, 245);
            this.exportButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(183, 27);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export list";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // cleanListButton
            // 
            this.cleanListButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cleanListButton.Location = new System.Drawing.Point(839, 297);
            this.cleanListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cleanListButton.Name = "cleanListButton";
            this.cleanListButton.Size = new System.Drawing.Size(183, 27);
            this.cleanListButton.TabIndex = 5;
            this.cleanListButton.Text = "Clean list";
            this.cleanListButton.UseVisualStyleBackColor = true;
            this.cleanListButton.Click += new System.EventHandler(this.CleanListButton_Click);
            // 
            // importFileDialog
            // 
            this.importFileDialog.DefaultExt = "xml";
            this.importFileDialog.InitialDirectory = "c:\\\\";
            this.importFileDialog.Title = "Choose document you want to import";
            // 
            // exportFileDialog
            // 
            this.exportFileDialog.DefaultExt = "xml";
            this.exportFileDialog.FileName = "apps.xml";
            this.exportFileDialog.Filter = "xml|";
            this.exportFileDialog.InitialDirectory = "c:\\\\";
            this.exportFileDialog.Title = "Choose directory where you want to save the list of apps";
            // 
            // UrlColumn
            // 
            this.UrlColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UrlColumn.HeaderText = "Url";
            this.UrlColumn.MinimumWidth = 6;
            this.UrlColumn.Name = "UrlColumn";
            // 
            // LastUpdatedColumn
            // 
            this.LastUpdatedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LastUpdatedColumn.HeaderText = "Last Updated";
            this.LastUpdatedColumn.MinimumWidth = 6;
            this.LastUpdatedColumn.Name = "LastUpdatedColumn";
            this.LastUpdatedColumn.ReadOnly = true;
            // 
            // IsDownloadedColumn
            // 
            this.IsDownloadedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsDownloadedColumn.HeaderText = "Is downloaded";
            this.IsDownloadedColumn.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.IsDownloadedColumn.MinimumWidth = 6;
            this.IsDownloadedColumn.Name = "IsDownloadedColumn";
            this.IsDownloadedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsDownloadedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsDownloadedColumn.Width = 109;
            // 
            // IsInstalledColumn
            // 
            this.IsInstalledColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsInstalledColumn.HeaderText = "Is installed";
            this.IsInstalledColumn.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.IsInstalledColumn.MinimumWidth = 6;
            this.IsInstalledColumn.Name = "IsInstalledColumn";
            this.IsInstalledColumn.Width = 68;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 516);
            this.Controls.Add(this.cleanListButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.downloadAndInstallButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.appsGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChillExe";
            ((System.ComponentModel.ISupportInitialize)(this.appsGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView appsGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton languageDropDown;
        private System.Windows.Forms.ToolStripMenuItem spanishDropdownMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishDropdownMenuItem;
        private System.Windows.Forms.Button downloadAndInstallButton;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button cleanListButton;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private System.Windows.Forms.SaveFileDialog exportFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrlColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdatedColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsDownloadedColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsInstalledColumn;
    }
}

