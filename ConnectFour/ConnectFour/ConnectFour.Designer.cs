namespace ConnectFour {
    partial class ConnectFour {
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
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.smallMessageLabel = new System.Windows.Forms.Label();
            this.bannerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bannerPanel
            // 
            this.bannerPanel.Controls.Add(this.closeButton);
            this.bannerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bannerPanel.Location = new System.Drawing.Point(0, 0);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(800, 30);
            this.bannerPanel.TabIndex = 0;
            this.bannerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bannerPanel_Paint);
            this.bannerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bannerPanel_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Red;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(430, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(29, 29);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // viewPanel
            // 
            this.viewPanel.Location = new System.Drawing.Point(20, 50);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(420, 470);
            this.viewPanel.TabIndex = 1;
            // 
            // smallMessageLabel
            // 
            this.smallMessageLabel.AutoSize = true;
            this.smallMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallMessageLabel.Location = new System.Drawing.Point(0, 520);
            this.smallMessageLabel.Name = "smallMessageLabel";
            this.smallMessageLabel.Size = new System.Drawing.Size(0, 20);
            this.smallMessageLabel.TabIndex = 2;
            // 
            // ConnectFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(460, 540);
            this.Controls.Add(this.smallMessageLabel);
            this.Controls.Add(this.bannerPanel);
            this.Controls.Add(this.viewPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConnectFour";
            this.Text = "Connect Four";
            this.bannerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label smallMessageLabel;
    }
}

