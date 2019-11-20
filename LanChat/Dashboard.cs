using LanChat.Networking;
using System;
using System.Windows.Forms;

namespace LanChat
{
    public partial class Dashboard : Form
    {
        public Dashboard() => this.InitializeComponent();

        private void button1_Click(object sender, System.EventArgs e)
        {
            backgroundWorkerServer.RunWorkerAsync();
        }

        private void MessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message);
            AddMessageSafe(e.Message);
        }

        private delegate void SafeCallDelegate(string message);
        private void AddMessageSafe(string message)
        {
            if (listBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddMessageSafe);
                listBox1.Invoke(d, new object[] { message });
            }
            else
            {
                listBox1.Items.Add(message);
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var client = new Client();
            client.SendMessage("testing");
            listBox1.Items.Add("testing");
        }

        private void backgroundWorkerServer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var server = new Server();
            server.MessageReceived += MessageReceived;
            server.Start();
        }
    }
}
