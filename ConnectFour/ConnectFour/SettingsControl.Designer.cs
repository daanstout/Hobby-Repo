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
            this.largeWinLengthButton = new System.Windows.Forms.Button();
            this.normalWinLengthButton = new System.Windows.Forms.Button();
            this.smallWinLengthButton = new System.Windows.Forms.Button();
            this.winLengthLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boardSizePanel.SuspendLayout();
            this.winLengthPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(135, 400);
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
            this.defaultBoardSizeLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultBoardSizeLabel_Paint);
            // 
            // winLengthPanel
            // 
            this.winLengthPanel.Controls.Add(this.largeWinLengthButton);
            this.winLengthPanel.Controls.Add(this.normalWinLengthButton);
            this.winLengthPanel.Controls.Add(this.smallWinLengthButton);
            this.winLengthPanel.Controls.Add(this.winLengthLabel);
            this.winLengthPanel.Controls.Add(this.label1);
            this.winLengthPanel.Location = new System.Drawing.Point(20, 120);
            this.winLengthPanel.Name = "winLengthPanel";
            this.winLengthPanel.Size = new System.Drawing.Size(354, 45);
            this.winLengthPanel.TabIndex = 8;
            // 
            // largeWinLengthButton
            // 
            this.largeWinLengthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.largeWinLengthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.largeWinLengthButton.ForeColor = System.Drawing.Color.White;
            this.largeWinLengthButton.Location = new System.Drawing.Point(281, 0);
            this.largeWinLengthButton.Name = "largeWinLengthButton";
            this.largeWinLengthButton.Size = new System.Drawing.Size(73, 30);
            this.largeWinLengthButton.TabIndex = 5;
            this.largeWinLengthButton.TabStop = false;
            this.largeWinLengthButton.Text = "5";
            this.largeWinLengthButton.UseVisualStyleBackColor = true;
            this.largeWinLengthButton.Click += new System.EventHandler(this.largeWinLengthButton_Click);
            // 
            // normalWinLengthButton
            // 
            this.normalWinLengthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalWinLengthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalWinLengthButton.ForeColor = System.Drawing.Color.White;
            this.normalWinLengthButton.Location = new System.Drawing.Point(207, 0);
            this.normalWinLengthButton.Name = "normalWinLengthButton";
            this.normalWinLengthButton.Size = new System.Drawing.Size(74, 30);
            this.normalWinLengthButton.TabIndex = 4;
            this.normalWinLengthButton.TabStop = false;
            this.normalWinLengthButton.Text = "4";
            this.normalWinLengthButton.UseVisualStyleBackColor = true;
            this.normalWinLengthButton.Click += new System.EventHandler(this.normalWinLengthButton_Click);
            // 
            // smallWinLengthButton
            // 
            this.smallWinLengthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.smallWinLengthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smallWinLengthButton.ForeColor = System.Drawing.Color.White;
            this.smallWinLengthButton.Location = new System.Drawing.Point(134, 0);
            this.smallWinLengthButton.Name = "smallWinLengthButton";
            this.smallWinLengthButton.Size = new System.Drawing.Size(73, 30);
            this.smallWinLengthButton.TabIndex = 3;
            this.smallWinLengthButton.TabStop = false;
            this.smallWinLengthButton.Text = "3";
            this.smallWinLengthButton.UseVisualStyleBackColor = true;
            this.smallWinLengthButton.Click += new System.EventHandler(this.smallWinLengthButton_Click);
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
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.defaultBoardSizeLabel_Paint);
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
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
        private System.Windows.Forms.Button largeWinLengthButton;
        private System.Windows.Forms.Button normalWinLengthButton;
        private System.Windows.Forms.Button smallWinLengthButton;
    }
}
