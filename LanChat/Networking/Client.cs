﻿using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LanChat.Networking
{
    public class Client
    {
        private string serverIP;
        public Client(string serverIP)
        {
            this.serverIP = serverIP;
        }
        public void SendMessage(string message)
        {
            SendMessage(message, this.serverIP);
        }

        public static void SendMessage(string message, string remoteIP)
        {
            var client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(remoteIP), 11000); // endpoint where server is listening
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
