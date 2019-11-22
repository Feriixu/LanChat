namespace LanChat
{
    partial class ServerBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonScan = new System.Windows.Forms.Button();
            this.listBoxServers = new System.Windows.Forms.ListBox();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonScan
            // 
            this.buttonScan.Location = new System.Drawing.Point(3, 3);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(173, 23);
            this.buttonScan.TabIndex = 0;
            this.buttonScan.Text = "Scan Local Network";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // listBoxServers
            // 
            this.listBoxServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxServers.FormattingEnabled = true;
            this.listBoxServers.Location = new System.Drawing.Point(3, 32);
            this.listBoxServers.Name = "listBoxServers";
            this.listBoxServers.Size = new System.Drawing.Size(173, 277);
            this.listBoxServers.TabIndex = 1;
            // 
            // buttonJoin
            // 
            this.buttonJoin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJoin.Location = new System.Drawing.Point(4, 316);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(172, 23);
            this.buttonJoin.TabIndex = 2;
            this.buttonJoin.Text = "Join Server";
            this.buttonJoin.UseVisualStyleBackColor = true;
            // 
            // ServerBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonJoin);
            this.Controls.Add(this.listBoxServers);
            this.Controls.Add(this.buttonScan);
            this.Name = "ServerBrowser";
            this.Size = new System.Drawing.Size(179, 342);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.ListBox listBoxServers;
        private System.Windows.Forms.Button buttonJoin;
    }
}
