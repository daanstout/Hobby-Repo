
namespace DnDDungeonGenerator {
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
            this.previewPanel = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.minRoomLabel = new System.Windows.Forms.Label();
            this.minRoomsNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxRoomsNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxRoomsLabel = new System.Windows.Forms.Label();
            this.roomsGeneratedLabel = new System.Windows.Forms.Label();
            this.normalRoomWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.normalRoomWeightLabel = new System.Windows.Forms.Label();
            this.treasureRoomWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.treasureRoomWeightLabel = new System.Windows.Forms.Label();
            this.maxTreasureRoomNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxTreasureRoomLabel = new System.Windows.Forms.Label();
            this.maxShopRoomNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxShopRoomLabel = new System.Windows.Forms.Label();
            this.shopRoomWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.shopRoomWeightLabel = new System.Windows.Forms.Label();
            this.maxMiniBossRoomNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxMiniBossRoomLabel = new System.Windows.Forms.Label();
            this.miniBossWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.miniBossRoomWeightLabel = new System.Windows.Forms.Label();
            this.maxPillarRoomNumeric = new System.Windows.Forms.NumericUpDown();
            this.pillarBossRoomLabel = new System.Windows.Forms.Label();
            this.pillarWeightNumeric = new System.Windows.Forms.NumericUpDown();
            this.pillarRoomWeightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minRoomsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRoomsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalRoomWeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treasureRoomWeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTreasureRoomNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxShopRoomNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopRoomWeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMiniBossRoomNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniBossWeightNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPillarRoomNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pillarWeightNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // previewPanel
            // 
            this.previewPanel.Location = new System.Drawing.Point(13, 13);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(600, 400);
            this.previewPanel.TabIndex = 0;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
            // 
            // generateButton
            // 
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateButton.ForeColor = System.Drawing.Color.White;
            this.generateButton.Location = new System.Drawing.Point(638, 13);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(200, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // minRoomLabel
            // 
            this.minRoomLabel.AutoSize = true;
            this.minRoomLabel.ForeColor = System.Drawing.Color.White;
            this.minRoomLabel.Location = new System.Drawing.Point(638, 43);
            this.minRoomLabel.Name = "minRoomLabel";
            this.minRoomLabel.Size = new System.Drawing.Size(71, 15);
            this.minRoomLabel.TabIndex = 2;
            this.minRoomLabel.Text = "Min Rooms:";
            // 
            // minRoomsNumeric
            // 
            this.minRoomsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.minRoomsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minRoomsNumeric.ForeColor = System.Drawing.Color.White;
            this.minRoomsNumeric.Location = new System.Drawing.Point(788, 44);
            this.minRoomsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minRoomsNumeric.Name = "minRoomsNumeric";
            this.minRoomsNumeric.Size = new System.Drawing.Size(50, 19);
            this.minRoomsNumeric.TabIndex = 3;
            this.minRoomsNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // maxRoomsNumeric
            // 
            this.maxRoomsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maxRoomsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxRoomsNumeric.ForeColor = System.Drawing.Color.White;
            this.maxRoomsNumeric.Location = new System.Drawing.Point(788, 74);
            this.maxRoomsNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.maxRoomsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxRoomsNumeric.Name = "maxRoomsNumeric";
            this.maxRoomsNumeric.Size = new System.Drawing.Size(50, 19);
            this.maxRoomsNumeric.TabIndex = 5;
            this.maxRoomsNumeric.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // maxRoomsLabel
            // 
            this.maxRoomsLabel.AutoSize = true;
            this.maxRoomsLabel.ForeColor = System.Drawing.Color.White;
            this.maxRoomsLabel.Location = new System.Drawing.Point(638, 73);
            this.maxRoomsLabel.Name = "maxRoomsLabel";
            this.maxRoomsLabel.Size = new System.Drawing.Size(73, 15);
            this.maxRoomsLabel.TabIndex = 4;
            this.maxRoomsLabel.Text = "Max Rooms:";
            // 
            // roomsGeneratedLabel
            // 
            this.roomsGeneratedLabel.AutoSize = true;
            this.roomsGeneratedLabel.ForeColor = System.Drawing.Color.White;
            this.roomsGeneratedLabel.Location = new System.Drawing.Point(638, 398);
            this.roomsGeneratedLabel.Name = "roomsGeneratedLabel";
            this.roomsGeneratedLabel.Size = new System.Drawing.Size(104, 15);
            this.roomsGeneratedLabel.TabIndex = 6;
            this.roomsGeneratedLabel.Text = "Rooms Generated:";
            // 
            // normalRoomWeightNumeric
            // 
            this.normalRoomWeightNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.normalRoomWeightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.normalRoomWeightNumeric.ForeColor = System.Drawing.Color.White;
            this.normalRoomWeightNumeric.Location = new System.Drawing.Point(788, 104);
            this.normalRoomWeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.normalRoomWeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.normalRoomWeightNumeric.Name = "normalRoomWeightNumeric";
            this.normalRoomWeightNumeric.Size = new System.Drawing.Size(50, 19);
            this.normalRoomWeightNumeric.TabIndex = 8;
            this.normalRoomWeightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // normalRoomWeightLabel
            // 
            this.normalRoomWeightLabel.AutoSize = true;
            this.normalRoomWeightLabel.ForeColor = System.Drawing.Color.White;
            this.normalRoomWeightLabel.Location = new System.Drawing.Point(638, 103);
            this.normalRoomWeightLabel.Name = "normalRoomWeightLabel";
            this.normalRoomWeightLabel.Size = new System.Drawing.Size(91, 15);
            this.normalRoomWeightLabel.TabIndex = 7;
            this.normalRoomWeightLabel.Text = "Normal Weight:";
            // 
            // treasureRoomWeightNumeric
            // 
            this.treasureRoomWeightNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.treasureRoomWeightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treasureRoomWeightNumeric.ForeColor = System.Drawing.Color.White;
            this.treasureRoomWeightNumeric.Location = new System.Drawing.Point(788, 134);
            this.treasureRoomWeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.treasureRoomWeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.treasureRoomWeightNumeric.Name = "treasureRoomWeightNumeric";
            this.treasureRoomWeightNumeric.Size = new System.Drawing.Size(50, 19);
            this.treasureRoomWeightNumeric.TabIndex = 10;
            this.treasureRoomWeightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // treasureRoomWeightLabel
            // 
            this.treasureRoomWeightLabel.AutoSize = true;
            this.treasureRoomWeightLabel.ForeColor = System.Drawing.Color.Red;
            this.treasureRoomWeightLabel.Location = new System.Drawing.Point(638, 133);
            this.treasureRoomWeightLabel.Name = "treasureRoomWeightLabel";
            this.treasureRoomWeightLabel.Size = new System.Drawing.Size(129, 15);
            this.treasureRoomWeightLabel.TabIndex = 9;
            this.treasureRoomWeightLabel.Text = "Treasure Room Weight:";
            // 
            // maxTreasureRoomNumeric
            // 
            this.maxTreasureRoomNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maxTreasureRoomNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxTreasureRoomNumeric.ForeColor = System.Drawing.Color.White;
            this.maxTreasureRoomNumeric.Location = new System.Drawing.Point(788, 164);
            this.maxTreasureRoomNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxTreasureRoomNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxTreasureRoomNumeric.Name = "maxTreasureRoomNumeric";
            this.maxTreasureRoomNumeric.Size = new System.Drawing.Size(50, 19);
            this.maxTreasureRoomNumeric.TabIndex = 12;
            this.maxTreasureRoomNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxTreasureRoomLabel
            // 
            this.maxTreasureRoomLabel.AutoSize = true;
            this.maxTreasureRoomLabel.ForeColor = System.Drawing.Color.Red;
            this.maxTreasureRoomLabel.Location = new System.Drawing.Point(638, 163);
            this.maxTreasureRoomLabel.Name = "maxTreasureRoomLabel";
            this.maxTreasureRoomLabel.Size = new System.Drawing.Size(119, 15);
            this.maxTreasureRoomLabel.TabIndex = 11;
            this.maxTreasureRoomLabel.Text = "Max Treasure Rooms:";
            // 
            // maxShopRoomNumeric
            // 
            this.maxShopRoomNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maxShopRoomNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxShopRoomNumeric.ForeColor = System.Drawing.Color.White;
            this.maxShopRoomNumeric.Location = new System.Drawing.Point(788, 224);
            this.maxShopRoomNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxShopRoomNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxShopRoomNumeric.Name = "maxShopRoomNumeric";
            this.maxShopRoomNumeric.Size = new System.Drawing.Size(50, 19);
            this.maxShopRoomNumeric.TabIndex = 16;
            this.maxShopRoomNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxShopRoomLabel
            // 
            this.maxShopRoomLabel.AutoSize = true;
            this.maxShopRoomLabel.ForeColor = System.Drawing.Color.Blue;
            this.maxShopRoomLabel.Location = new System.Drawing.Point(638, 223);
            this.maxShopRoomLabel.Name = "maxShopRoomLabel";
            this.maxShopRoomLabel.Size = new System.Drawing.Size(103, 15);
            this.maxShopRoomLabel.TabIndex = 15;
            this.maxShopRoomLabel.Text = "Max Shop Rooms:";
            // 
            // shopRoomWeightNumeric
            // 
            this.shopRoomWeightNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.shopRoomWeightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shopRoomWeightNumeric.ForeColor = System.Drawing.Color.White;
            this.shopRoomWeightNumeric.Location = new System.Drawing.Point(788, 194);
            this.shopRoomWeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.shopRoomWeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.shopRoomWeightNumeric.Name = "shopRoomWeightNumeric";
            this.shopRoomWeightNumeric.Size = new System.Drawing.Size(50, 19);
            this.shopRoomWeightNumeric.TabIndex = 14;
            this.shopRoomWeightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shopRoomWeightLabel
            // 
            this.shopRoomWeightLabel.AutoSize = true;
            this.shopRoomWeightLabel.ForeColor = System.Drawing.Color.Blue;
            this.shopRoomWeightLabel.Location = new System.Drawing.Point(638, 193);
            this.shopRoomWeightLabel.Name = "shopRoomWeightLabel";
            this.shopRoomWeightLabel.Size = new System.Drawing.Size(113, 15);
            this.shopRoomWeightLabel.TabIndex = 13;
            this.shopRoomWeightLabel.Text = "Shop Room Weight:";
            // 
            // maxMiniBossRoomNumeric
            // 
            this.maxMiniBossRoomNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maxMiniBossRoomNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxMiniBossRoomNumeric.ForeColor = System.Drawing.Color.White;
            this.maxMiniBossRoomNumeric.Location = new System.Drawing.Point(788, 284);
            this.maxMiniBossRoomNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxMiniBossRoomNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxMiniBossRoomNumeric.Name = "maxMiniBossRoomNumeric";
            this.maxMiniBossRoomNumeric.Size = new System.Drawing.Size(50, 19);
            this.maxMiniBossRoomNumeric.TabIndex = 20;
            this.maxMiniBossRoomNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxMiniBossRoomLabel
            // 
            this.maxMiniBossRoomLabel.AutoSize = true;
            this.maxMiniBossRoomLabel.ForeColor = System.Drawing.Color.Yellow;
            this.maxMiniBossRoomLabel.Location = new System.Drawing.Point(638, 283);
            this.maxMiniBossRoomLabel.Name = "maxMiniBossRoomLabel";
            this.maxMiniBossRoomLabel.Size = new System.Drawing.Size(127, 15);
            this.maxMiniBossRoomLabel.TabIndex = 19;
            this.maxMiniBossRoomLabel.Text = "Max Mini Boss Rooms:";
            // 
            // miniBossWeightNumeric
            // 
            this.miniBossWeightNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.miniBossWeightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.miniBossWeightNumeric.ForeColor = System.Drawing.Color.White;
            this.miniBossWeightNumeric.Location = new System.Drawing.Point(788, 254);
            this.miniBossWeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.miniBossWeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.miniBossWeightNumeric.Name = "miniBossWeightNumeric";
            this.miniBossWeightNumeric.Size = new System.Drawing.Size(50, 19);
            this.miniBossWeightNumeric.TabIndex = 18;
            this.miniBossWeightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // miniBossRoomWeightLabel
            // 
            this.miniBossRoomWeightLabel.AutoSize = true;
            this.miniBossRoomWeightLabel.ForeColor = System.Drawing.Color.Yellow;
            this.miniBossRoomWeightLabel.Location = new System.Drawing.Point(638, 253);
            this.miniBossRoomWeightLabel.Name = "miniBossRoomWeightLabel";
            this.miniBossRoomWeightLabel.Size = new System.Drawing.Size(137, 15);
            this.miniBossRoomWeightLabel.TabIndex = 17;
            this.miniBossRoomWeightLabel.Text = "Mini Boss Room Weight:";
            // 
            // maxPillarRoomNumeric
            // 
            this.maxPillarRoomNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.maxPillarRoomNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxPillarRoomNumeric.ForeColor = System.Drawing.Color.White;
            this.maxPillarRoomNumeric.Location = new System.Drawing.Point(788, 344);
            this.maxPillarRoomNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxPillarRoomNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxPillarRoomNumeric.Name = "maxPillarRoomNumeric";
            this.maxPillarRoomNumeric.Size = new System.Drawing.Size(50, 19);
            this.maxPillarRoomNumeric.TabIndex = 24;
            this.maxPillarRoomNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pillarBossRoomLabel
            // 
            this.pillarBossRoomLabel.AutoSize = true;
            this.pillarBossRoomLabel.ForeColor = System.Drawing.Color.Green;
            this.pillarBossRoomLabel.Location = new System.Drawing.Point(638, 343);
            this.pillarBossRoomLabel.Name = "pillarBossRoomLabel";
            this.pillarBossRoomLabel.Size = new System.Drawing.Size(102, 15);
            this.pillarBossRoomLabel.TabIndex = 23;
            this.pillarBossRoomLabel.Text = "Max Pillar Rooms:";
            // 
            // pillarWeightNumeric
            // 
            this.pillarWeightNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pillarWeightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pillarWeightNumeric.ForeColor = System.Drawing.Color.White;
            this.pillarWeightNumeric.Location = new System.Drawing.Point(788, 314);
            this.pillarWeightNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pillarWeightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pillarWeightNumeric.Name = "pillarWeightNumeric";
            this.pillarWeightNumeric.Size = new System.Drawing.Size(50, 19);
            this.pillarWeightNumeric.TabIndex = 22;
            this.pillarWeightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pillarRoomWeightLabel
            // 
            this.pillarRoomWeightLabel.AutoSize = true;
            this.pillarRoomWeightLabel.ForeColor = System.Drawing.Color.Green;
            this.pillarRoomWeightLabel.Location = new System.Drawing.Point(638, 313);
            this.pillarRoomWeightLabel.Name = "pillarRoomWeightLabel";
            this.pillarRoomWeightLabel.Size = new System.Drawing.Size(112, 15);
            this.pillarRoomWeightLabel.TabIndex = 21;
            this.pillarRoomWeightLabel.Text = "Pillar Room Weight:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(850, 450);
            this.Controls.Add(this.maxPillarRoomNumeric);
            this.Controls.Add(this.pillarBossRoomLabel);
            this.Controls.Add(this.pillarWeightNumeric);
            this.Controls.Add(this.pillarRoomWeightLabel);
            this.Controls.Add(this.maxMiniBossRoomNumeric);
            this.Controls.Add(this.maxMiniBossRoomLabel);
            this.Controls.Add(this.miniBossWeightNumeric);
            this.Controls.Add(this.miniBossRoomWeightLabel);
            this.Controls.Add(this.maxShopRoomNumeric);
            this.Controls.Add(this.maxShopRoomLabel);
            this.Controls.Add(this.shopRoomWeightNumeric);
            this.Controls.Add(this.shopRoomWeightLabel);
            this.Controls.Add(this.maxTreasureRoomNumeric);
            this.Controls.Add(this.maxTreasureRoomLabel);
            this.Controls.Add(this.treasureRoomWeightNumeric);
            this.Controls.Add(this.treasureRoomWeightLabel);
            this.Controls.Add(this.normalRoomWeightNumeric);
            this.Controls.Add(this.normalRoomWeightLabel);
            this.Controls.Add(this.roomsGeneratedLabel);
            this.Controls.Add(this.maxRoomsNumeric);
            this.Controls.Add(this.maxRoomsLabel);
            this.Controls.Add(this.minRoomsNumeric);
            this.Controls.Add(this.minRoomLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.previewPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.minRoomsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxRoomsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalRoomWeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treasureRoomWeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTreasureRoomNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxShopRoomNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopRoomWeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxMiniBossRoomNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniBossWeightNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPillarRoomNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pillarWeightNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label minRoomLabel;
        private System.Windows.Forms.NumericUpDown minRoomsNumeric;
        private System.Windows.Forms.NumericUpDown maxRoomsNumeric;
        private System.Windows.Forms.Label maxRoomsLabel;
        private System.Windows.Forms.Label roomsGeneratedLabel;
        private System.Windows.Forms.NumericUpDown normalRoomWeightNumeric;
        private System.Windows.Forms.Label normalRoomWeightLabel;
        private System.Windows.Forms.NumericUpDown treasureRoomWeightNumeric;
        private System.Windows.Forms.Label treasureRoomWeightLabel;
        private System.Windows.Forms.NumericUpDown maxTreasureRoomNumeric;
        private System.Windows.Forms.Label maxTreasureRoomLabel;
        private System.Windows.Forms.NumericUpDown maxShopRoomNumeric;
        private System.Windows.Forms.Label maxShopRoomLabel;
        private System.Windows.Forms.NumericUpDown shopRoomWeightNumeric;
        private System.Windows.Forms.Label shopRoomWeightLabel;
        private System.Windows.Forms.NumericUpDown maxMiniBossRoomNumeric;
        private System.Windows.Forms.Label maxMiniBossRoomLabel;
        private System.Windows.Forms.NumericUpDown miniBossWeightNumeric;
        private System.Windows.Forms.Label miniBossRoomWeightLabel;
        private System.Windows.Forms.NumericUpDown maxPillarRoomNumeric;
        private System.Windows.Forms.Label pillarBossRoomLabel;
        private System.Windows.Forms.NumericUpDown pillarWeightNumeric;
        private System.Windows.Forms.Label pillarRoomWeightLabel;
        private System.Windows.Forms.Label rR;
        private System.Windows.Forms.Label oomW;
    }
}

