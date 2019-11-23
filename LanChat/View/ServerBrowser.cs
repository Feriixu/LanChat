using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanChat.Networking;

namespace LanChat.View
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

            var localMask = Addressing.GetSubnetMask(localIP);
            var hosts = Addressing.ScanNetwork(localIP, localMask);
            listBoxServers.DataSource = hosts;
            listBoxServers.DisplayMember = "Address";
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            if (listBoxServers.SelectedIndex != -1)
            {
                Dashboard.Instance.ShowChatRoom(listBoxServers.SelectedValue.ToString());
            }
        }
    }
}