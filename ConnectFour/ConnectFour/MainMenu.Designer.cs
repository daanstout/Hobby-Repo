namespace ConnectFour {
    partial class MainMenu {
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
            this.playRegularButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.connectThreeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playRegularButton
            // 
            this.playRegularButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playRegularButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playRegularButton.ForeColor = System.Drawing.Color.White;
            this.playRegularButton.Location = new System.Drawing.Point(135, 60);
            this.playRegularButton.Name = "playRegularButton";
            this.playRegularButton.Size = new System.Drawing.Size(150, 35);
            this.playRegularButton.TabIndex = 0;
            this.playRegularButton.Text = "Connect Four";
            this.playRegularButton.UseVisualStyleBackColor = true;
            this.playRegularButton.Click += new System.EventHandler(this.playRegularButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(135, 160);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(150, 35);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // connectThreeButton
            // 
            this.connectThreeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectThreeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectThreeButton.ForeColor = System.Drawing.Color.White;
            this.connectThreeButton.Location = new System.Drawing.Point(135, 110);
            this.connectThreeButton.Name = "connectThreeButton";
            this.connectThreeButton.Size = new System.Drawing.Size(150, 35);
            this.connectThreeButton.TabIndex = 2;
            this.connectThreeButton.Text = "Three Players";
            this.connectThreeButton.UseVisualStyleBackColor = true;
            this.connectThreeButton.Click += new System.EventHandler(this.connectThreeButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.connectThreeButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.playRegularButton);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(420, 470);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playRegularButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button connectThreeButton;
    }
}
