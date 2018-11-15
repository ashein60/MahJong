namespace Andrew_s_MahJong
{
    partial class MahJong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.backgroundsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.playToolStripMenuItem.Text = "New Game";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.Click_NewGame);
            // 
            // backgroundsToolStripMenuItem
            // 
            this.backgroundsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomToolStripMenuItem,
            this.cubeToolStripMenuItem,
            this.fenceToolStripMenuItem,
            this.poolToolStripMenuItem});
            this.backgroundsToolStripMenuItem.Name = "backgroundsToolStripMenuItem";
            this.backgroundsToolStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.backgroundsToolStripMenuItem.Text = "Maps";
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.randomToolStripMenuItem.Text = "Random";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.Click_Random);
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.cubeToolStripMenuItem.Text = "Cube";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.Click_Cube);
            // 
            // fenceToolStripMenuItem
            // 
            this.fenceToolStripMenuItem.Name = "fenceToolStripMenuItem";
            this.fenceToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.fenceToolStripMenuItem.Text = "Fence";
            this.fenceToolStripMenuItem.Click += new System.EventHandler(this.Click_Fence);
            // 
            // poolToolStripMenuItem
            // 
            this.poolToolStripMenuItem.Name = "poolToolStripMenuItem";
            this.poolToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.poolToolStripMenuItem.Text = "Pool";
            this.poolToolStripMenuItem.Click += new System.EventHandler(this.Click_Pool);
            // 
            // MahJong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MahJong";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Andrew\'s MahJong";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_Everything);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Down);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poolToolStripMenuItem;
    }
}

