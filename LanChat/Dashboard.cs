﻿using LanChat.Networking;
using System;
using System.Windows.Forms;

namespace LanChat
{
    public partial class Dashboard : Form
    {
        public Dashboard() => this.InitializeComponent();

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

        private void backgroundWorkerServer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var server = new Server(true);
            server.MessageReceived += MessageReceived;
            server.Listen();
        }
    }
}
