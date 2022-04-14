
namespace ChillExe.Controls
{
    partial class CheckboxMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckboxMessageBox));
            this.dontShowAgainCheckbox = new System.Windows.Forms.CheckBox();
            this.messageBoxText = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.messageBoxToolStrip = new System.Windows.Forms.ToolStrip();
            this.messageBoxTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripClosebutton = new System.Windows.Forms.ToolStripButton();
            this.messageBoxToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dontShowAgainCheckbox
            // 
            this.dontShowAgainCheckbox.AutoSize = true;
            this.dontShowAgainCheckbox.Location = new System.Drawing.Point(241, 150);
            this.dontShowAgainCheckbox.Name = "dontShowAgainCheckbox";
            this.dontShowAgainCheckbox.Size = new System.Drawing.Size(143, 24);
            this.dontShowAgainCheckbox.TabIndex = 1;
            this.dontShowAgainCheckbox.Text = "Dont show again";
            this.dontShowAgainCheckbox.UseVisualStyleBackColor = true;
            // 
            // messageBoxText
            // 
            this.messageBoxText.AutoSize = true;
            this.messageBoxText.Location = new System.Drawing.Point(10, 80);
            this.messageBoxText.Name = "messageBoxText";
            this.messageBoxText.Size = new System.Drawing.Size(125, 20);
            this.messageBoxText.TabIndex = 2;
            this.messageBoxText.Text = "Message Box text";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(260, 205);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(94, 29);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // messageBoxToolStrip
            // 
            this.messageBoxToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.messageBoxToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageBoxTitle,
            this.toolStripClosebutton});
            this.messageBoxToolStrip.Location = new System.Drawing.Point(0, 0);
            this.messageBoxToolStrip.Name = "messageBoxToolStrip";
            this.messageBoxToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.messageBoxToolStrip.Size = new System.Drawing.Size(606, 27);
            this.messageBoxToolStrip.TabIndex = 4;
            this.messageBoxToolStrip.Text = "messageBoxToolstrip";
            // 
            // messageBoxTitle
            // 
            this.messageBoxTitle.Name = "messageBoxTitle";
            this.messageBoxTitle.Size = new System.Drawing.Size(126, 24);
            this.messageBoxTitle.Text = "Message box title";
            // 
            // toolStripClosebutton
            // 
            this.toolStripClosebutton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripClosebutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripClosebutton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClosebutton.Image")));
            this.toolStripClosebutton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripClosebutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClosebutton.Name = "toolStripClosebutton";
            this.toolStripClosebutton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripClosebutton.RightToLeftAutoMirrorImage = true;
            this.toolStripClosebutton.Size = new System.Drawing.Size(29, 24);
            this.toolStripClosebutton.Text = "X";
            this.toolStripClosebutton.Click += new System.EventHandler(this.toolStripClosebutton_Click);
            // 
            // CheckboxMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.messageBoxToolStrip);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.messageBoxText);
            this.Controls.Add(this.dontShowAgainCheckbox);
            this.Name = "CheckboxMessageBox";
            this.Size = new System.Drawing.Size(606, 255);
            this.messageBoxToolStrip.ResumeLayout(false);
            this.messageBoxToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox dontShowAgainCheckbox;
        private System.Windows.Forms.Label messageBoxText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolStrip messageBoxToolStrip;
        private System.Windows.Forms.ToolStripLabel messageBoxTitle;
        private System.Windows.Forms.ToolStripButton toolStripClosebutton;
    }
}
