namespace ConnectFour {
    partial class SettingsControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.backButton = new System.Windows.Forms.Button();
            this.sizeSmallButton = new System.Windows.Forms.Button();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.sizeNormalButton = new System.Windows.Forms.Button();
            this.sizeLargeButton = new System.Windows.Forms.Button();
            this.sizeExtraLargeButton = new System.Windows.Forms.Button();
            this.boardSizePanel = new System.Windows.Forms.Panel();
            this.defaultBoardSizeLabel = new System.Windows.Forms.Label();
            this.winLengthPanel = new System.Windows.Forms.Panel();
            this.winLengthLargeButton = new System.Windows.Forms.Button();
            this.winLengthNormalButton = new System.Windows.Forms.Button();
            this.winLengthSmallButton = new System.Windows.Forms.Button();
            this.winLengthLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.defaultButton = new System.Windows.Forms.Button();
            this.boardSizePanel.SuspendLayout();
            this.winLengthPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(245, 400);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(150, 35);
            this.backButton.TabIndex = 1;
            this.backButton.TabStop = false;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // sizeSmallButton
            // 
            this.sizeSmallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeSmallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeSmallButton.ForeColor = System.Drawing.Color.White;
            this.sizeSmallButton.Location = new System.Drawing.Point(134, 0);
            this.sizeSmallButton.Name = "sizeSmallButton";
            this.sizeSmallButton.Size = new System.Drawing.Size(100, 30);
            this.sizeSmallButton.TabIndex = 2;
            this.sizeSmallButton.TabStop = false;
            this.sizeSmallButton.Text = "5x4";
            this.sizeSmallButton.UseVisualStyleBackColor = true;
            this.sizeSmallButton.Click += new System.EventHandler(this.sizeSmallButton_Click);
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardSizeLabel.ForeColor = System.Drawing.Color.White;
            this.boardSizeLabel.Location = new System.Drawing.Point(0, 15);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(114, 25);
            this.boardSizeLabel.TabIndex = 3;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // sizeNormalButton
            // 
            this.sizeNormalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeNormalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeNormalButton.ForeColor = System.Drawing.Color.White;
            this.sizeNormalButton.Location = new System.Drawing.Point(254, 0);
            this.sizeNormalButton.Name = "sizeNormalButton";
            this.sizeNormalButton.Size = new System.Drawing.Size(100, 30);
            this.sizeNormalButton.TabIndex = 4;
            this.sizeNormalButton.TabStop = false;
            this.sizeNormalButton.Text = "7x6";
            this.sizeNormalButton.UseVisualStyleBackColor = true;
            this.sizeNormalButton.Click += new System.EventHandler(this.sizeNormalButton_Click);
            // 
            // sizeLargeButton
            // 
            this.sizeLargeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeLargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLargeButton.ForeColor = System.Drawing.Color.White;
            this.sizeLargeButton.Location = new System.Drawing.Point(134, 50);
            this.sizeLargeButton.Name = "sizeLargeButton";
            this.sizeLargeButton.Size = new System.Drawing.Size(100, 30);
            this.sizeLargeButton.TabIndex = 5;
            this.sizeLargeButton.TabStop = false;
            this.sizeLargeButton.Text = "9x8";
            this.sizeLargeButton.UseVisualStyleBackColor = true;
            this.sizeLargeButton.Click += new System.EventHandler(this.sizeLargeButton_Click);
            // 
            // sizeExtraLargeButton
            // 
            this.sizeExtraLargeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sizeExtraLargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeExtraLargeButton.ForeColor = System.Drawing.Color.White;
            this.sizeExtraLargeButton.Location = new System.Drawing.Point(254, 50);
            this.sizeExtraLargeButton.Name = "sizeExtraLargeButton";
            this.sizeExtraLargeButton.Size = new System.Drawing.Size(100, 30);
            this.sizeExtraLargeButton.TabIndex = 6;
            this.sizeExtraLargeButton.TabStop = false;
            this.sizeExtraLargeButton.Text = "11x10";
            this.sizeExtraLargeButton.UseVisualStyleBackColor = true;
            this.sizeExtraLargeButton.Click += new System.EventHandler(this.sizeExtraLargeButton_Click);
            // 
            // boardSizePanel
            // 
            this.boardSizePanel.Controls.Add(this.sizeNormalButton);
            this.boardSizePanel.Controls.Add(this.boardSizeLabel);
            this.boardSizePanel.Controls.Add(this.sizeLargeButton);
            this.boardSizePanel.Controls.Add(this.sizeSmallButton);
            this.boardSizePanel.Controls.Add(this.sizeExtraLargeButton);
            this.boardSizePanel.Controls.Add(this.defaultBoardSizeLabel);
            this.boardSizePanel.Location = new System.Drawing.Point(20, 20);
            this.boardSizePanel.Name = "boardSizePanel";
            this.boardSizePanel.Size = new System.Drawing.Size(354, 80);
            this.boardSizePanel.TabIndex = 7;
            // 
            // defaultBoardSizeLabel
            // 
            this.defaultBoardSizeLabel.AutoSize = true;
            this.defaultBoardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultBoardSizeLabel.ForeColor = System.Drawing.Color.White;
            this.defaultBoardSizeLabel.Location = new System.Drawing.Point(282, 28);
            this.defaultBoardSizeLabel.Name = "defaultBoardSizeLabel";
            this.defaultBoardSizeLabel.Size = new System.Drawing.Size(44, 15);
            this.defaultBoardSizeLabel.TabIndex = 7;
            this.defaultBoardSizeLabel.Text = "default";
            this.defaultBoardSizeLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultLabel_Paint);
            // 
            // winLengthPanel
            // 
            this.winLengthPanel.Controls.Add(this.winLengthLargeButton);
            this.winLengthPanel.Controls.Add(this.winLengthNormalButton);
            this.winLengthPanel.Controls.Add(this.winLengthSmallButton);
            this.winLengthPanel.Controls.Add(this.winLengthLabel);
            this.winLengthPanel.Controls.Add(this.label1);
            this.winLengthPanel.Location = new System.Drawing.Point(20, 120);
            this.winLengthPanel.Name = "winLengthPanel";
            this.winLengthPanel.Size = new System.Drawing.Size(354, 45);
            this.winLengthPanel.TabIndex = 8;
            // 
            // winLengthLargeButton
            // 
            this.winLengthLargeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winLengthLargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLengthLargeButton.ForeColor = System.Drawing.Color.White;
            this.winLengthLargeButton.Location = new System.Drawing.Point(281, 0);
            this.winLengthLargeButton.Name = "winLengthLargeButton";
            this.winLengthLargeButton.Size = new System.Drawing.Size(73, 30);
            this.winLengthLargeButton.TabIndex = 5;
            this.winLengthLargeButton.TabStop = false;
            this.winLengthLargeButton.Text = "5";
            this.winLengthLargeButton.UseVisualStyleBackColor = true;
            this.winLengthLargeButton.Click += new System.EventHandler(this.winLengthLargeButton_Click);
            // 
            // winLengthNormalButton
            // 
            this.winLengthNormalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winLengthNormalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLengthNormalButton.ForeColor = System.Drawing.Color.White;
            this.winLengthNormalButton.Location = new System.Drawing.Point(207, 0);
            this.winLengthNormalButton.Name = "winLengthNormalButton";
            this.winLengthNormalButton.Size = new System.Drawing.Size(74, 30);
            this.winLengthNormalButton.TabIndex = 4;
            this.winLengthNormalButton.TabStop = false;
            this.winLengthNormalButton.Text = "4";
            this.winLengthNormalButton.UseVisualStyleBackColor = true;
            this.winLengthNormalButton.Click += new System.EventHandler(this.winLengthNormalButton_Click);
            // 
            // winLengthSmallButton
            // 
            this.winLengthSmallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winLengthSmallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLengthSmallButton.ForeColor = System.Drawing.Color.White;
            this.winLengthSmallButton.Location = new System.Drawing.Point(134, 0);
            this.winLengthSmallButton.Name = "winLengthSmallButton";
            this.winLengthSmallButton.Size = new System.Drawing.Size(73, 30);
            this.winLengthSmallButton.TabIndex = 3;
            this.winLengthSmallButton.TabStop = false;
            this.winLengthSmallButton.Text = "3";
            this.winLengthSmallButton.UseVisualStyleBackColor = true;
            this.winLengthSmallButton.Click += new System.EventHandler(this.winLengthSmallButton_Click);
            // 
            // winLengthLabel
            // 
            this.winLengthLabel.AutoSize = true;
            this.winLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.winLengthLabel.ForeColor = System.Drawing.Color.White;
            this.winLengthLabel.Location = new System.Drawing.Point(0, 7);
            this.winLengthLabel.Name = "winLengthLabel";
            this.winLengthLabel.Size = new System.Drawing.Size(118, 25);
            this.winLengthLabel.TabIndex = 0;
            this.winLengthLabel.Text = "Win Length:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(222, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "default";
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultLabel_Paint);
            // 
            // defaultButton
            // 
            this.defaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultButton.ForeColor = System.Drawing.Color.White;
            this.defaultButton.Location = new System.Drawing.Point(25, 400);
            this.defaultButton.Name = "defaultButton";
            this.defaultButton.Size = new System.Drawing.Size(150, 35);
            this.defaultButton.TabIndex = 9;
            this.defaultButton.TabStop = false;
            this.defaultButton.Text = "Default";
            this.defaultButton.UseVisualStyleBackColor = true;
            this.defaultButton.Click += new System.EventHandler(this.defaultButton_Click);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.defaultButton);
            this.Controls.Add(this.winLengthPanel);
            this.Controls.Add(this.boardSizePanel);
            this.Controls.Add(this.backButton);
            this.DoubleBuffered = true;
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(420, 470);
            this.boardSizePanel.ResumeLayout(false);
            this.boardSizePanel.PerformLayout();
            this.winLengthPanel.ResumeLayout(false);
            this.winLengthPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button sizeSmallButton;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Button sizeNormalButton;
        private System.Windows.Forms.Button sizeLargeButton;
        private System.Windows.Forms.Button sizeExtraLargeButton;
        private System.Windows.Forms.Panel boardSizePanel;
        private System.Windows.Forms.Label defaultBoardSizeLabel;
        private System.Windows.Forms.Panel winLengthPanel;
        private System.Windows.Forms.Label winLengthLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button winLengthLargeButton;
        private System.Windows.Forms.Button winLengthNormalButton;
        private System.Windows.Forms.Button winLengthSmallButton;
        private System.Windows.Forms.Button defaultButton;
    }
}
