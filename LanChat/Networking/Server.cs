using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace LanChat.Networking
{
    public class Server
    {
        public bool Distribute { get; private set; }
        private List<ChatClient> chatClients;
        public Server(bool distribute)
        {
            this.Distribute = distribute;
            this.chatClients = new List<ChatClient>();
        }

        public void Listen()
        {
            var udpServer = new UdpClient(11000);

            while (true)
            {
                var remoteEP = new IPEndPoint(IPAddress.Any, 11000);
                var data = udpServer.Receive(ref remoteEP); // listen on port 11000
                udpServer.Send(new byte[] { (byte)OPCode.Ack }, 1, remoteEP); // Reply with Ack
                switch ((OPCode)data[0])
                {
                    case OPCode.Discover:
                        break;
                    case OPCode.Ack:
                        break;
                    case OPCode.Message:
                        var message = System.Text.Encoding.UTF8.GetString(data.Skip(1).ToArray());
                        this.OnMessageReceived(message);
                        if (this.Distribute)
                        {
                            DistributeMessage(message);
                        }
                        // Distribute message
                        break;
                    case OPCode.Connect:
                        break;
                    case OPCode.Disconnect:
                        break;
                    default:
                        break;
                }
                Console.WriteLine("receive data from " + remoteEP.ToString());
                udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
            }
        }

        private void DistributeMessage(string message)
        {
            foreach (var client in chatClients)
            {
                Client.SendMessage(message: message, remoteIP: client.IP);
            }
        }       

        public event EventHandler<MessageEventArgs> MessageReceived;
        private void OnMessageReceived(string message)
        {
            var e = new MessageEventArgs(message);
            MessageReceived?.Invoke(this, e);
        }
    }
}
