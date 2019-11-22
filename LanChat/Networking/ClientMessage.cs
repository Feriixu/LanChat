using System;

namespace LanChat.Networking
{
    public class ClientMessage
    {
        public string Content { get; private set; }
        public DateTime Timestamp { get; private set; }
        public ClientMessage(string content)
        {
            this.Content = content;
            this.Timestamp = DateTime.UtcNow;
        }
    }
}
