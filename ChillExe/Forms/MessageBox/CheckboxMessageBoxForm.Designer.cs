
namespace ChillExe.Forms.MessageBox
{
    partial class CheckboxMessageBoxForm
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
            this.messageBoxText = new System.Windows.Forms.Label();
            this.notShowAgainCheckbox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // messageBoxText
            // 
            this.messageBoxText.AutoEllipsis = true;
            this.messageBoxText.AutoSize = true;
            this.messageBoxText.Location = new System.Drawing.Point(93, 63);
            this.messageBoxText.MaximumSize = new System.Drawing.Size(350, 75);
            this.messageBoxText.Name = "messageBoxText";
            this.messageBoxText.Size = new System.Drawing.Size(319, 30);
            this.messageBoxText.TabIndex = 0;
            this.messageBoxText.Text = "This is the default text in checkbox message box, u have to overwrite this.";
            // 
            // notShowAgainCheckbox
            // 
            this.notShowAgainCheckbox.AutoSize = true;
            this.notShowAgainCheckbox.Location = new System.Drawing.Point(152, 125);
            this.notShowAgainCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.notShowAgainCheckbox.Name = "notShowAgainCheckbox";
            this.notShowAgainCheckbox.Size = new System.Drawing.Size(118, 19);
            this.notShowAgainCheckbox.TabIndex = 1;
            this.notShowAgainCheckbox.Text = "Don\'t show again";
            this.notShowAgainCheckbox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(170, 175);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(82, 22);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChillExe.Properties.Resources.warning_icon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // CheckboxMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 226);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.notShowAgainCheckbox);
            this.Controls.Add(this.messageBoxText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CheckboxMessageBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Important information";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageBoxText;
        private System.Windows.Forms.Button okButton;
        internal System.Windows.Forms.CheckBox notShowAgainCheckbox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}