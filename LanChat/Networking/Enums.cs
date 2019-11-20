using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanChat.Networking
{
    enum OPCode
    {
        Discover = 0,
        Ack = 1,
        Message = 2,
        Connect = 3,
        Disconnect = 4
    }
}
