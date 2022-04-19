
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
            this.SuspendLayout();
            // 
            // messageBoxText
            // 
            this.messageBoxText.AutoEllipsis = true;
            this.messageBoxText.AutoSize = true;
            this.messageBoxText.Location = new System.Drawing.Point(69, 89);
            this.messageBoxText.MaximumSize = new System.Drawing.Size(600, 100);
            this.messageBoxText.Name = "messageBoxText";
            this.messageBoxText.Size = new System.Drawing.Size(491, 20);
            this.messageBoxText.TabIndex = 0;
            this.messageBoxText.Text = "This is the default text in checkbox message box, u have to overwrite this.";
            // 
            // notShowAgainCheckbox
            // 
            this.notShowAgainCheckbox.AutoSize = true;
            this.notShowAgainCheckbox.Location = new System.Drawing.Point(248, 181);
            this.notShowAgainCheckbox.Name = "notShowAgainCheckbox";
            this.notShowAgainCheckbox.Size = new System.Drawing.Size(146, 24);
            this.notShowAgainCheckbox.TabIndex = 1;
            this.notShowAgainCheckbox.Text = "Don\'t show again";
            this.notShowAgainCheckbox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(269, 239);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(94, 29);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // CheckboxMessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 301);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.notShowAgainCheckbox);
            this.Controls.Add(this.messageBoxText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckboxMessageBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Important information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageBoxText;
        private System.Windows.Forms.Button okButton;
        internal System.Windows.Forms.CheckBox notShowAgainCheckbox;
    }
}