﻿namespace HobbyProjects {
    partial class HobbyProjects {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainMenuPanel = new System.Windows.Forms.Panel();
            this.mainViewPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mainMenuPanel
            // 
            this.mainMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.mainMenuPanel.Name = "mainMenuPanel";
            this.mainMenuPanel.Size = new System.Drawing.Size(150, 860);
            this.mainMenuPanel.TabIndex = 0;
            // 
            // mainViewPanel
            // 
            this.mainViewPanel.ForeColor = System.Drawing.Color.White;
            this.mainViewPanel.Location = new System.Drawing.Point(157, 13);
            this.mainViewPanel.Name = "mainViewPanel";
            this.mainViewPanel.Size = new System.Drawing.Size(1300, 830);
            this.mainViewPanel.TabIndex = 1;
            // 
            // HobbyProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1484, 861);
            this.Controls.Add(this.mainViewPanel);
            this.Controls.Add(this.mainMenuPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HobbyProjects";
            this.Text = "Hobby Projects";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainMenuPanel;
        private System.Windows.Forms.Panel mainViewPanel;
    }
}

