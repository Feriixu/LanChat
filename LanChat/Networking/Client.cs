using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LanChat.Networking
{
    public class Client
    {
        public void SendMessage(string message)
        {
            var client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000); // endpoint where server is listening
            client.Connect(ep);

            // send data
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var opcodeBytes = new byte[] { (byte)OPCode.Message };
            var packet = opcodeBytes.Concat(messageBytes).ToArray();
            client.Send(packet, packet.Length);
            // then receive data
            var receivedData = client.Receive(ref ep);

            Console.WriteLine("sent message to " + ep.ToString());
        }
    }
}
