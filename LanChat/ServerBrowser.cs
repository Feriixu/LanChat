using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using LanChat.Networking;

namespace LanChat
{
    public partial class ServerBrowser : UserControl
    {
        public ServerBrowser()
        {
            InitializeComponent();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            var localIP = Addressing.GetLocalIP();
            if (localIP == null)
            {
                MessageBox.Show("You don't have a local IP Address. Are you connected to a network?", "Network error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }
    }


}

namespace LanChat.Networking
{
    public static class Addressing
    {
        public static string GetLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                Console.WriteLine(ip);
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            return null;
        }

        public static string[] ScanNetwork(string ip, string mask)
        {

        }
    }
}
