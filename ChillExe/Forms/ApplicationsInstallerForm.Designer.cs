
using ChillExe.Controls;

namespace ChillExe
{
    partial class ApplicationsInstallerForm
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
            this.programsControl = new ChillExe.Controls.ApplicationsInstallerControl();
            this.SuspendLayout();
            // 
            // programsControl
            // 
            this.programsControl.Location = new System.Drawing.Point(101, 36);
            this.programsControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.programsControl.Name = "elementsList1";
            this.programsControl.Size = new System.Drawing.Size(594, 324);
            this.programsControl.TabIndex = 0;
            // 
            // ProgramsForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 452);
            this.Controls.Add(this.programsControl);
            this.Name = "Form1";
            this.Text = "ChillExe";
            this.ResumeLayout(false);

        }

        #endregion
        private ApplicationsInstallerControl programsControl;
    }
}

