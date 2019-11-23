using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace LanChat.Networking
{
    public static class Addressing
    {
        public static IPAddress GetLocalIP()
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

        public static List<IPEndPoint> ScanNetwork(IPAddress ip, IPAddress mask)
        {
            int networkAddress = GetNetworkAddress(ip, mask);
            int amountHosts = GetAmountOfHosts(mask);
            var hosts = new List<IPEndPoint>();
            for (int i = 1; i <= amountHosts; i++)
            {
                var num = networkAddress + i;
                var newIP = IPAddress.Parse(num.ToString());
                hosts.Add(new IPEndPoint(newIP, 11000));
            }

            List<IPEndPoint> discoveredEPs = new List<IPEndPoint>();
            var client = new UdpClient();
            client.Client.SendTimeout = 100;
            client.Client.ReceiveTimeout = 100;
            var discoverMsg = new byte[] { (byte)OPCode.Discover };
            for (int i = 0; i < hosts.Count; i++)
            {
                try
                {
                    var host = hosts[i];
                    client.Send(discoverMsg, discoverMsg.Length, host);
                    var response = client.Receive(ref host);
                    discoveredEPs.Add(host);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return discoveredEPs;
        }

        public static int GetNetworkAddress(IPAddress ip, IPAddress mask)
        {
            byte[] ipBytes = ip.GetAddressBytes();
            int ipBits = ipBytes[0] << 24 | ipBytes[1] << 16 | ipBytes[2] << 8 | ipBytes[3];
            byte[] maskBytes = mask.GetAddressBytes();
            int maskBits = maskBytes[0] << 24 | maskBytes[1] << 16 | maskBytes[2] << 8 | maskBytes[3];
            int netAddr = ipBits & maskBits;
            return netAddr;
        }

        public static int GetAmountOfHosts(IPAddress mask)
        {
            byte[] maskBytes = mask.GetAddressBytes();
            long maskBits = maskBytes[0] << 24 | maskBytes[1] << 16 | maskBytes[2] << 8 | maskBytes[3];
            int counter = 0;
            int hosts = 0;
            while ((maskBits & 1) == 0)
            {
                hosts += (int)Math.Pow(2, counter);
                counter++;
                maskBits = maskBits >> 1;
            }
            return hosts;
        }

        public static IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));
        }

    }
}
