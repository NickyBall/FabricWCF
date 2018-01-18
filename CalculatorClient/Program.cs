using Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new BasicHttpsBinding();

            // WCF Initialize
            var Channel = new ChannelFactory<ICalculatorService>(binding);

            // Reverse Proxy
            var Endpoint = new EndpointAddress("https://localhost:19081/FabricWCFTest/Calculator");
            // Actual Endpoint
            //var Endpoint = new EndpointAddress("https://localhost:30010/268e6642-bf46-416e-964b-9b2d576b618b/10038860-a4f2-4c61-9398-ac7c106fbb90-131607217756439444");
            ServicePointManager.ServerCertificateValidationCallback +=
                (se, cert, chain, sslerror) =>
                {
                    return true;
                };
            var Service = Channel.CreateChannel(Endpoint);

            var result = Service.Add(2, 3);

            Console.WriteLine(result);
        }
    }
}
