namespace CommonAncestor {
    partial class CommonAncestor {
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
            this.banner = new System.Windows.Forms.Panel();
            this.ancestorTreePanel = new System.Windows.Forms.Panel();
            this.drawButton = new System.Windows.Forms.Button();
            this.nextGenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // banner
            // 
            this.banner.Location = new System.Drawing.Point(0, 0);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(400, 25);
            this.banner.TabIndex = 0;
            this.banner.Paint += new System.Windows.Forms.PaintEventHandler(this.Banner_Paint);
            this.banner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Banner_MouseDown);
            // 
            // ancestorTreePanel
            // 
            this.ancestorTreePanel.Location = new System.Drawing.Point(0, 25);
            this.ancestorTreePanel.Name = "ancestorTreePanel";
            this.ancestorTreePanel.Size = new System.Drawing.Size(300, 575);
            this.ancestorTreePanel.TabIndex = 1;
            this.ancestorTreePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.AncestorTreePanel_Paint);
            // 
            // drawButton
            // 
            this.drawButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drawButton.Location = new System.Drawing.Point(315, 32);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(70, 23);
            this.drawButton.TabIndex = 2;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // nextGenButton
            // 
            this.nextGenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextGenButton.Location = new System.Drawing.Point(315, 61);
            this.nextGenButton.Name = "nextGenButton";
            this.nextGenButton.Size = new System.Drawing.Size(70, 46);
            this.nextGenButton.TabIndex = 3;
            this.nextGenButton.Text = "Next Generation";
            this.nextGenButton.UseVisualStyleBackColor = true;
            this.nextGenButton.Click += new System.EventHandler(this.NextGenButton_Click);
            // 
            // CommonAncestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.nextGenButton);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.ancestorTreePanel);
            this.Controls.Add(this.banner);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommonAncestor";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel banner;
        private System.Windows.Forms.Panel ancestorTreePanel;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button nextGenButton;
    }
}

