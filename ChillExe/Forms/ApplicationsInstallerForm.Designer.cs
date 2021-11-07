
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
            this.programsControl.Location = new System.Drawing.Point(115, 48);
            this.programsControl.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.programsControl.Name = "programsControl";
            this.programsControl.Size = new System.Drawing.Size(679, 432);
            this.programsControl.TabIndex = 0;
            // 
            // ApplicationsInstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 603);
            this.Controls.Add(this.programsControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ApplicationsInstallerForm";
            this.Text = "ChillExe";
            this.ResumeLayout(false);

        }

        #endregion
        private ApplicationsInstallerControl programsControl;
    }
}

