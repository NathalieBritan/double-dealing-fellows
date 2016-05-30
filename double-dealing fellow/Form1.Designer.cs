namespace double_dealing_fellow
{
    partial class MainBoard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personVsPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prsonVsPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Sp_Date = new System.Windows.Forms.ToolStripStatusLabel();
            this.Sp_Count = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(520, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.gameToolStripMenuItem.Text = "New Game";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.gameToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personVsPersonToolStripMenuItem,
            this.prsonVsPCToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Players";
            // 
            // personVsPersonToolStripMenuItem
            // 
            this.personVsPersonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("personVsPersonToolStripMenuItem.Image")));
            this.personVsPersonToolStripMenuItem.Name = "personVsPersonToolStripMenuItem";
            this.personVsPersonToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.personVsPersonToolStripMenuItem.Tag = "Person";
            this.personVsPersonToolStripMenuItem.Text = "Person vs Person";
            this.personVsPersonToolStripMenuItem.Click += new System.EventHandler(this.personVsPersonToolStripMenuItem_Click);
            // 
            // prsonVsPCToolStripMenuItem
            // 
            this.prsonVsPCToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("prsonVsPCToolStripMenuItem.Image")));
            this.prsonVsPCToolStripMenuItem.Name = "prsonVsPCToolStripMenuItem";
            this.prsonVsPCToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.prsonVsPCToolStripMenuItem.Tag = "PC";
            this.prsonVsPCToolStripMenuItem.Text = "Person vs PC";
            this.prsonVsPCToolStripMenuItem.Click += new System.EventHandler(this.prsonVsPCToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sp_Date,
            this.Sp_Count});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(520, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Sp_Date
            // 
            this.Sp_Date.Name = "Sp_Date";
            this.Sp_Date.Size = new System.Drawing.Size(118, 17);
            this.Sp_Date.Text = "toolStripStatusLabel1";
            // 
            // Sp_Count
            // 
            this.Sp_Count.Name = "Sp_Count";
            this.Sp_Count.Size = new System.Drawing.Size(118, 17);
            this.Sp_Count.Text = "toolStripStatusLabel1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Double-dealing fellow\r\n";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(520, 566);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MenuStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainBoard";
            this.Text = "Double-dealing fellows";
            this.Deactivate += new System.EventHandler(this.MainBoard_Deactivate);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Sp_Date;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripStatusLabel Sp_Count;
        private System.Windows.Forms.ToolStripMenuItem personVsPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prsonVsPCToolStripMenuItem;
    }
}

