using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [ServiceContract]
    public interface IChatCallbackService
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string Username, string Message);
    }
}
