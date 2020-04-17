namespace MediaManager.ViewControls {
    partial class MoviesUserControl {
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
            this.moviesPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // moviesPanel
            // 
            this.moviesPanel.Location = new System.Drawing.Point(20, 20);
            this.moviesPanel.Name = "moviesPanel";
            this.moviesPanel.Size = new System.Drawing.Size(1120, 690);
            this.moviesPanel.TabIndex = 0;
            this.moviesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.moviesPanel_Paint);
            // 
            // MoviesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.moviesPanel);
            this.Name = "MoviesUserControl";
            this.Size = new System.Drawing.Size(1160, 730);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel moviesPanel;
    }
}
