
namespace RayMarching {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.view = new System.Windows.Forms.Panel();
            this.frameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.Location = new System.Drawing.Point(199, 123);
            this.view.Name = "view";
            this.view.Size = new System.Drawing.Size(200, 200);
            this.view.TabIndex = 0;
            // 
            // frameTimer
            // 
            this.frameTimer.Interval = 16;
            this.frameTimer.Tick += new System.EventHandler(this.frameTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.view);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel view;
        private System.Windows.Forms.Timer frameTimer;
    }
}

