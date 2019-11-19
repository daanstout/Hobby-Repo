namespace VisualBrainFuckInterpreter {
    partial class BrainfuckInterpreter {
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
            this.programTextbox = new System.Windows.Forms.RichTextBox();
            this.validProgramLabel = new System.Windows.Forms.Label();
            this.bannerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bannerPanel
            // 
            this.bannerPanel.Controls.Add(this.closeButton);
            this.bannerPanel.Font = new System.Drawing.Font("Cascadia Code", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bannerPanel.Location = new System.Drawing.Point(0, 0);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(1000, 30);
            this.bannerPanel.TabIndex = 0;
            this.bannerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bannerPanel_Paint);
            this.bannerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bannerPanel_MouseDown);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Red;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(971, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(29, 29);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // programTextbox
            // 
            this.programTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.programTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.programTextbox.ForeColor = System.Drawing.Color.White;
            this.programTextbox.Location = new System.Drawing.Point(25, 55);
            this.programTextbox.Name = "programTextbox";
            this.programTextbox.Size = new System.Drawing.Size(500, 300);
            this.programTextbox.TabIndex = 2;
            this.programTextbox.Text = "";
            this.programTextbox.WordWrap = false;
            this.programTextbox.TextChanged += new System.EventHandler(this.programTextbox_TextChanged);
            this.programTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.programTextbox_KeyPress);
            // 
            // validProgramLabel
            // 
            this.validProgramLabel.AutoSize = true;
            this.validProgramLabel.Location = new System.Drawing.Point(544, 55);
            this.validProgramLabel.Name = "validProgramLabel";
            this.validProgramLabel.Size = new System.Drawing.Size(115, 14);
            this.validProgramLabel.TabIndex = 3;
            this.validProgramLabel.Text = "Program Valid: Yes";
            // 
            // BrainfuckInterpreter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.validProgramLabel);
            this.Controls.Add(this.programTextbox);
            this.Controls.Add(this.bannerPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrainfuckInterpreter";
            this.Text = "Brainfuck Interpreter";
            this.bannerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.RichTextBox programTextbox;
        private System.Windows.Forms.Label validProgramLabel;
    }
}

