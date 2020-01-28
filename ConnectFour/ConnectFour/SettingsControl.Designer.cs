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
            this.defaultWinLengthLabel = new System.Windows.Forms.Label();
            this.defaultButton = new System.Windows.Forms.Button();
            this.aiDifficultyPanel = new System.Windows.Forms.Panel();
            this.aiHardButton = new System.Windows.Forms.Button();
            this.aiNormalButton = new System.Windows.Forms.Button();
            this.aiEasyButton = new System.Windows.Forms.Button();
            this.aiDifficultyLabel = new System.Windows.Forms.Label();
            this.defaultAIDifficulyLabel = new System.Windows.Forms.Label();
            this.boardSizePanel.SuspendLayout();
            this.winLengthPanel.SuspendLayout();
            this.aiDifficultyPanel.SuspendLayout();
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
            this.winLengthPanel.Controls.Add(this.defaultWinLengthLabel);
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
            // defaultWinLengthLabel
            // 
            this.defaultWinLengthLabel.AutoSize = true;
            this.defaultWinLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultWinLengthLabel.ForeColor = System.Drawing.Color.White;
            this.defaultWinLengthLabel.Location = new System.Drawing.Point(222, 28);
            this.defaultWinLengthLabel.Name = "defaultWinLengthLabel";
            this.defaultWinLengthLabel.Size = new System.Drawing.Size(44, 15);
            this.defaultWinLengthLabel.TabIndex = 8;
            this.defaultWinLengthLabel.Text = "default";
            this.defaultWinLengthLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultLabel_Paint);
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
            // aiDifficultyPanel
            // 
            this.aiDifficultyPanel.Controls.Add(this.aiHardButton);
            this.aiDifficultyPanel.Controls.Add(this.aiNormalButton);
            this.aiDifficultyPanel.Controls.Add(this.aiEasyButton);
            this.aiDifficultyPanel.Controls.Add(this.aiDifficultyLabel);
            this.aiDifficultyPanel.Controls.Add(this.defaultAIDifficulyLabel);
            this.aiDifficultyPanel.Location = new System.Drawing.Point(20, 185);
            this.aiDifficultyPanel.Name = "aiDifficultyPanel";
            this.aiDifficultyPanel.Size = new System.Drawing.Size(354, 45);
            this.aiDifficultyPanel.TabIndex = 10;
            // 
            // aiHardButton
            // 
            this.aiHardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aiHardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aiHardButton.ForeColor = System.Drawing.Color.White;
            this.aiHardButton.Location = new System.Drawing.Point(281, 0);
            this.aiHardButton.Name = "aiHardButton";
            this.aiHardButton.Size = new System.Drawing.Size(73, 30);
            this.aiHardButton.TabIndex = 8;
            this.aiHardButton.TabStop = false;
            this.aiHardButton.Text = "Hard";
            this.aiHardButton.UseVisualStyleBackColor = true;
            this.aiHardButton.Click += new System.EventHandler(this.aiHardButton_Click);
            // 
            // aiNormalButton
            // 
            this.aiNormalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aiNormalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aiNormalButton.ForeColor = System.Drawing.Color.White;
            this.aiNormalButton.Location = new System.Drawing.Point(207, 0);
            this.aiNormalButton.Name = "aiNormalButton";
            this.aiNormalButton.Size = new System.Drawing.Size(74, 30);
            this.aiNormalButton.TabIndex = 7;
            this.aiNormalButton.TabStop = false;
            this.aiNormalButton.Text = "Normal";
            this.aiNormalButton.UseVisualStyleBackColor = true;
            this.aiNormalButton.Click += new System.EventHandler(this.aiNormalButton_Click);
            // 
            // aiEasyButton
            // 
            this.aiEasyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aiEasyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aiEasyButton.ForeColor = System.Drawing.Color.White;
            this.aiEasyButton.Location = new System.Drawing.Point(134, 0);
            this.aiEasyButton.Name = "aiEasyButton";
            this.aiEasyButton.Size = new System.Drawing.Size(73, 30);
            this.aiEasyButton.TabIndex = 6;
            this.aiEasyButton.TabStop = false;
            this.aiEasyButton.Text = "Easy";
            this.aiEasyButton.UseVisualStyleBackColor = true;
            this.aiEasyButton.Click += new System.EventHandler(this.aiEasyButton_Click);
            // 
            // aiDifficultyLabel
            // 
            this.aiDifficultyLabel.AutoSize = true;
            this.aiDifficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.aiDifficultyLabel.ForeColor = System.Drawing.Color.White;
            this.aiDifficultyLabel.Location = new System.Drawing.Point(0, 7);
            this.aiDifficultyLabel.Name = "aiDifficultyLabel";
            this.aiDifficultyLabel.Size = new System.Drawing.Size(114, 25);
            this.aiDifficultyLabel.TabIndex = 1;
            this.aiDifficultyLabel.Text = "AI Difficulty:";
            // 
            // defaultAIDifficulyLabel
            // 
            this.defaultAIDifficulyLabel.AutoSize = true;
            this.defaultAIDifficulyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultAIDifficulyLabel.ForeColor = System.Drawing.Color.White;
            this.defaultAIDifficulyLabel.Location = new System.Drawing.Point(222, 28);
            this.defaultAIDifficulyLabel.Name = "defaultAIDifficulyLabel";
            this.defaultAIDifficulyLabel.Size = new System.Drawing.Size(44, 15);
            this.defaultAIDifficulyLabel.TabIndex = 9;
            this.defaultAIDifficulyLabel.Text = "default";
            this.defaultAIDifficulyLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultLabel_Paint);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.aiDifficultyPanel);
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
            this.aiDifficultyPanel.ResumeLayout(false);
            this.aiDifficultyPanel.PerformLayout();
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
        private System.Windows.Forms.Label defaultWinLengthLabel;
        private System.Windows.Forms.Button winLengthLargeButton;
        private System.Windows.Forms.Button winLengthNormalButton;
        private System.Windows.Forms.Button winLengthSmallButton;
        private System.Windows.Forms.Button defaultButton;
        private System.Windows.Forms.Panel aiDifficultyPanel;
        private System.Windows.Forms.Button aiHardButton;
        private System.Windows.Forms.Button aiNormalButton;
        private System.Windows.Forms.Button aiEasyButton;
        private System.Windows.Forms.Label aiDifficultyLabel;
        private System.Windows.Forms.Label defaultAIDifficulyLabel;
    }
}
