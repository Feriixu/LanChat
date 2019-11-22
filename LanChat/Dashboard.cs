using LanChat.Networking;
using System;
using System.Windows.Forms;

namespace LanChat
{
    public partial class Dashboard : Form
    {
        public UserControl ActiveControl { get; set; }

        public Dashboard() => this.InitializeComponent();

        private void MessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message);
            AddMessageSafe(e.Message);
        }

        private delegate void SafeCallDelegate(string message);
        private void AddMessageSafe(string message)
        {
            if (listBoxMessages.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddMessageSafe);
                listBoxMessages.Invoke(d, new object[] { message });
            }
            else
            {
                listBoxMessages.Items.Add(message);
            }
        }

        private void backgroundWorkerServer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var server = new Server(true);
            server.MessageReceived += MessageReceived;
            server.Listen();
        }

        private void joinRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Remove(ActiveControl);
            this.flowLayoutPanel1.Controls.Add(new ServerBrowser());
        }
    }
}
