namespace ResourceManager {
    partial class ResourceManager {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceManager));
            this.resourcePanel = new System.Windows.Forms.Panel();
            this.resourcePanelToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resourceMenuPanel = new System.Windows.Forms.Panel();
            this.mainViewPanel = new System.Windows.Forms.Panel();
            this.mainViewMenuPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // resourcePanel
            // 
            resources.ApplyResources(this.resourcePanel, "resourcePanel");
            this.resourcePanel.Name = "resourcePanel";
            this.resourcePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.resourcePanel_Paint);
            this.resourcePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resourcePanel_MouseMove);
            // 
            // resourceMenuPanel
            // 
            resources.ApplyResources(this.resourceMenuPanel, "resourceMenuPanel");
            this.resourceMenuPanel.Name = "resourceMenuPanel";
            // 
            // mainViewPanel
            // 
            resources.ApplyResources(this.mainViewPanel, "mainViewPanel");
            this.mainViewPanel.Name = "mainViewPanel";
            // 
            // mainViewMenuPanel
            // 
            resources.ApplyResources(this.mainViewMenuPanel, "mainViewMenuPanel");
            this.mainViewMenuPanel.Name = "mainViewMenuPanel";
            // 
            // ResourceManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.mainViewMenuPanel);
            this.Controls.Add(this.mainViewPanel);
            this.Controls.Add(this.resourceMenuPanel);
            this.Controls.Add(this.resourcePanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ResourceManager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel resourcePanel;
        private System.Windows.Forms.ToolTip resourcePanelToolTip;
        private System.Windows.Forms.Panel resourceMenuPanel;
        private System.Windows.Forms.Panel mainViewPanel;
        private System.Windows.Forms.Panel mainViewMenuPanel;
    }
}

