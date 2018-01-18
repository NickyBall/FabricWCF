using Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input Endpoint: ");
            string InputEndpoint = Console.ReadLine();
            // WCF Binding
            var binding = new WSDualHttpBinding();

            // For Duplex Callback
            InstanceContext CallbackContext = new InstanceContext(new ChatClient());
            
            // Duplex Initialize
            DuplexChannelFactory<IChatService> Channel = new DuplexChannelFactory<IChatService>(CallbackContext, binding);
            EndpointAddress Endpoint = new EndpointAddress(InputEndpoint);

            // Create Duplex Channel
            var Service = Channel.CreateChannel(Endpoint);

            Console.Write("Enter Username: ");
            string Username = Console.ReadLine();

            Service.Subscribe(Username);

            while (true)
            {
                Console.Write("Enter Message: ");
                string Message = Console.ReadLine();
                Service.SendMessage(Username, Message);
            }
            
        }
    }
}
