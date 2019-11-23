namespace LanChat
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.backgroundWorkerServer = new System.ComponentModel.BackgroundWorker();
            this.menuStripToolbar = new System.Windows.Forms.MenuStrip();
            this.chatroomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStripToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripToolbar
            // 
            this.menuStripToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatroomsToolStripMenuItem});
            this.menuStripToolbar.Location = new System.Drawing.Point(0, 0);
            this.menuStripToolbar.Name = "menuStripToolbar";
            this.menuStripToolbar.Size = new System.Drawing.Size(580, 24);
            this.menuStripToolbar.TabIndex = 3;
            this.menuStripToolbar.Text = "menuStrip1";
            // 
            // chatroomsToolStripMenuItem
            // 
            this.chatroomsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.joinRoomToolStripMenuItem});
            this.chatroomsToolStripMenuItem.Name = "chatroomsToolStripMenuItem";
            this.chatroomsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.chatroomsToolStripMenuItem.Text = "Chatrooms";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createToolStripMenuItem.Image")));
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createToolStripMenuItem.Text = "Create Room";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // joinRoomToolStripMenuItem
            // 
            this.joinRoomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("joinRoomToolStripMenuItem.Image")));
            this.joinRoomToolStripMenuItem.Name = "joinRoomToolStripMenuItem";
            this.joinRoomToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.joinRoomToolStripMenuItem.Text = "Join Room";
            this.joinRoomToolStripMenuItem.Click += new System.EventHandler(this.joinRoomToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanelMain.Name = "flowLayoutPanel1";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(100, 100);
            this.flowLayoutPanelMain.TabIndex = 4;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(580, 364);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.menuStripToolbar);
            this.MainMenuStrip = this.menuStripToolbar;
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.menuStripToolbar.ResumeLayout(false);
            this.menuStripToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerServer;
        private System.Windows.Forms.MenuStrip menuStripToolbar;
        private System.Windows.Forms.ToolStripMenuItem chatroomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem joinRoomToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
    }
}

