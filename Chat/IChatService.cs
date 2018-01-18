using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IChatCallbackService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string Username, string Message);
        [OperationContract(IsOneWay = true)]
        void Subscribe(string Username);
    }
}
