using LanChat.View;
using System;
using System.Windows.Forms;

namespace LanChat
{
    public partial class Dashboard : Form
    {
        public static Dashboard Instance;
        public Dashboard()
        {
            this.InitializeComponent();
            Instance = this;
        }

        private void joinRoomToolStripMenuItem_Click(object sender, EventArgs e) => ShowServerBrowser();

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flowLayoutPanelMain.Controls.Clear();
            flowLayoutPanelMain.Controls.Add(new ChatRoom(true));
        }

        public void ShowServerBrowser()
        {
            this.flowLayoutPanelMain.Controls.Clear();
            this.flowLayoutPanelMain.Controls.Add(new ServerBrowser());
        }

        internal void ShowChatRoom(string serverIP)
        {
            this.flowLayoutPanelMain.Controls.Clear();
            this.flowLayoutPanelMain.Controls.Add(new ChatRoom(false, serverIP));
        }
    }
}
