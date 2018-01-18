using Microsoft.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatActor.Interfaces
{
    public interface IChatEvent : IActorEvents
    {
        void IncommingMesaggeTrigger(string Username, string Message);
    }
}
