namespace TowerDefense {
    partial class TowerDefense {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TowerDefense));
            this.gamePanel = new System.Windows.Forms.Panel();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.GameLoopWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            resources.ApplyResources(this.gamePanel, "gamePanel");
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            // 
            // bannerPanel
            // 
            resources.ApplyResources(this.bannerPanel, "bannerPanel");
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BannerPanel_MouseDown);
            // 
            // GameLoopWorker
            // 
            this.GameLoopWorker.WorkerSupportsCancellation = true;
            this.GameLoopWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GameLoopWorker_DoWork);
            this.GameLoopWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.GameLoopWorker_RunWorkerCompleted);
            // 
            // TowerDefense
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.bannerPanel);
            this.Controls.Add(this.gamePanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "TowerDefense";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Panel bannerPanel;
        private System.ComponentModel.BackgroundWorker GameLoopWorker;
    }
}

