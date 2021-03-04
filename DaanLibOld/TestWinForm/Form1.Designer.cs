namespace TestWinForm {
    partial class Form1 {
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
            this.horizontalMenuPanel = new System.Windows.Forms.Panel();
            this.verticalMenuPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // horizontalMenuPanel
            // 
            this.horizontalMenuPanel.Location = new System.Drawing.Point(13, 13);
            this.horizontalMenuPanel.Name = "horizontalMenuPanel";
            this.horizontalMenuPanel.Size = new System.Drawing.Size(600, 80);
            this.horizontalMenuPanel.TabIndex = 0;
            // 
            // verticalMenuPanel
            // 
            this.verticalMenuPanel.Location = new System.Drawing.Point(620, 13);
            this.verticalMenuPanel.Name = "verticalMenuPanel";
            this.verticalMenuPanel.Size = new System.Drawing.Size(100, 350);
            this.verticalMenuPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.verticalMenuPanel);
            this.Controls.Add(this.horizontalMenuPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel horizontalMenuPanel;
        private System.Windows.Forms.Panel verticalMenuPanel;
    }
}

