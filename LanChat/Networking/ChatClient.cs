using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanChat.Networking
{
    class ChatClient
    {
        public string Name { get; private set; }
        public string IP { get; private set; }
        public List<ClientMessage> clientMessages { get; private set; }

        public ChatClient(string name, string ip)
        {
            this.Name = name;
            this.IP = ip;
            this.clientMessages = new List<ClientMessage>();
        }

        public void AddMessage(string message)
        {
            clientMessages.Add(new ClientMessage(message));
        }
    }
}
