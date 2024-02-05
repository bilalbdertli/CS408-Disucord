using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CS408Project_Server
{
    class User
    {
        public string Username { get; }
        public Socket Socket { get; }
        public bool isSubscribedToIF100 { get; set; }
        public bool isSubscribedToSPS101 { get; set; }


        public User(string username, Socket socket)
        {
            Username = username;
            Socket = socket;
            isSubscribedToIF100 = false;
            isSubscribedToSPS101 = false;
        }
    }
}
