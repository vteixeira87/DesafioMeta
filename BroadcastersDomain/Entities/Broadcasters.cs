using BroadcastersCrossCutting.Entities;
using BroadcastersDomain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersDomain.Entities
{
    public class Broadcasters : BroadcastersAudit
    {

        public Broadcasters() { }

        public Broadcasters(int id, string name) 
        {
            AddNotifications(new BroadcastersContract(id, name));

            Id = id;
            Name = name.ToLower();
        } 

        public string Name { get; private set; }

        internal void NameUnavailable()
        {
            AddNotification("BroadcasterName", "Broadcaster name already registered");
        }
    }
}
