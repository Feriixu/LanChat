using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanChat.Networking;
using System.Net;

namespace LanChat.View
{
    public partial class ChatRoom : UserControl
    {
        private bool host;
        private BackgroundWorker ServerWorker;
        private string serverIP;
        Server server;
        Client client;

        public ChatRoom(bool distribute, string serverIP = "")
        {
            InitializeComponent();
            this.host = distribute;
            this.serverIP = serverIP;
            ServerWorker = new BackgroundWorker();
            ServerWorker.DoWork += ServerWorker_DoWork;
            ServerWorker.RunWorkerAsync();
        }

        private void ServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.client = new Client(this.serverIP);
            this.server = new Server(this.host);
            server.MessageReceived += MessageReceived;
            server.Listen();
        }

        private void MessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message);
            AddMessageSafe(e.Message);
        }

        private delegate void SafeCallDelegate(string message);
        private void AddMessageSafe(string message)
        {
            if (this.richTextBoxMessages.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddMessageSafe);
                this.richTextBoxMessages.Invoke(d, new object[] { message });
            }
            else
            {
                this.richTextBoxMessages.AppendText(message + "\n");
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var message = textBoxMessage.Text;
            if (message == null)
                return;

            if (this.host)
            {
                this.server.DistributeMessage(message);
            }
            else
            {
                this.client.SendMessage(message);
            }
        }
    }
}
