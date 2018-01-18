using Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class ChatClient : IChatCallbackService
    {
        public void ReceiveMessage(string Username, string Message)
        {
            Console.WriteLine($"{Username} : {Message}");
        }
    }
}
