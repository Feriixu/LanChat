using System;
using System.Net;
using LanChat.Networking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanChatTests
{
    [TestClass]
    public class UnitTestsAddressing
    {
        [TestMethod]
        public void TestGetSubnetMask()
        {
            var ip = Addressing.GetLocalIP();
            var mask = Addressing.GetSubnetMask(ip);
            var amountHosts = Addressing.GetAmountOfHosts(mask);
            var maskNum = Addressing.ScanNetwork(ip, mask);
        }

        [TestMethod]
        public void TestGetLocalIP()
        {
            try
            {
                var ip = Addressing.GetLocalIP();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestGetNetworkAddress()
        {
            var ip = Addressing.GetLocalIP();
            var mask = Addressing.GetSubnetMask(ip);
            var netAddr = Addressing.GetNetworkAddress(ip, mask);

        }

        [TestMethod]
        public void TestGetAmountHosts()
        {
            var amount = Addressing.GetAmountOfHosts(IPAddress.Parse("255.255.255.0"));
            Assert.AreEqual(amount, 255);
        }
    }
}
