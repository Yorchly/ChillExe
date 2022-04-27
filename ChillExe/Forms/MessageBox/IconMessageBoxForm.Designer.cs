namespace ChillExe.Forms.MessageBox
{
    partial class IconMessageBoxForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IconMessageBoxForm));
            this.okButton = new System.Windows.Forms.Button();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.iconMessageBoxFormText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(210, 188);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(94, 29);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // iconsList
            // 
            this.iconsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsList.Images.SetKeyName(0, "error-icon.png");
            this.iconsList.Images.SetKeyName(1, "ok-icon.png");
            this.iconsList.Images.SetKeyName(2, "warning-icon.png");
            // 
            // iconMessageBoxFormText
            // 
            this.iconMessageBoxFormText.BackColor = System.Drawing.SystemColors.Control;
            this.iconMessageBoxFormText.FlatAppearance.BorderSize = 0;
            this.iconMessageBoxFormText.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.iconMessageBoxFormText.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.iconMessageBoxFormText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconMessageBoxFormText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconMessageBoxFormText.ImageList = this.iconsList;
            this.iconMessageBoxFormText.Location = new System.Drawing.Point(69, 47);
            this.iconMessageBoxFormText.Name = "iconMessageBoxFormText";
            this.iconMessageBoxFormText.Size = new System.Drawing.Size(399, 80);
            this.iconMessageBoxFormText.TabIndex = 1;
            this.iconMessageBoxFormText.Text = "This is the default text of iconMessageBoxForm";
            this.iconMessageBoxFormText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconMessageBoxFormText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconMessageBoxFormText.UseVisualStyleBackColor = false;
            // 
            // IconMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 258);
            this.Controls.Add(this.iconMessageBoxFormText);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "IconMessageBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Important information";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.Button iconMessageBoxFormText;
    }
}