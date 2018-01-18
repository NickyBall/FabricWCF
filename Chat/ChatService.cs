using ChatActor.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class ChatService : IChatService, IChatEvent
    {
        Dictionary<string, IChatCallbackService> _CallbackDict;
        Dictionary<string, IChatCallbackService> CallbackDict
        {
            get
            {
                if (_CallbackDict == null) _CallbackDict = new Dictionary<string, IChatCallbackService>();
                return _CallbackDict;
            }
            set
            {
                _CallbackDict = value;
            }
        }
        IChatActor ChatActor;
        public ChatService()
        {
            // Communication Listener with actor
            ChatActor = ActorProxy.Create<IChatActor>(
                new ActorId("ChatActor1"),
                applicationName: "fabric:/FabricWCFTest",
                serviceName: "ChatActorService"
                );
            // For Callback
            ChatActor.SubscribeAsync<IChatEvent>(this);
        }
        public void IncommingMesaggeTrigger(string Username, string Message)
        {
            foreach (var Callback in CallbackDict)
            {
                if (Callback.Key.Equals(Username)) continue;
                Callback.Value.ReceiveMessage(Username, Message);
            }
        }

        public void SendMessage(string Username, string Message)
        {
            ChatActor.BroadcastMessage(Username, Message);
        }

        public void Subscribe(string Username)
        {
            OperationContext CurrentContext = OperationContext.Current;
            var Callback = CurrentContext.GetCallbackChannel<IChatCallbackService>();

            CallbackDict[Username] = Callback;
        }
    }
}
