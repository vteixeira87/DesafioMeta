﻿using BroadcastersCrossCutting.Entities;
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

        public void Update(string name)
        {
            AddNotifications(new BroadcastersContract(name));

            Name = name.ToLower();
        }

        public void UpdateBrodcasters()
        {
            AddNotification("UpdateBrodcasters", "Non-existent broadcaster for update");
        }

        public void NameUnavailable()
        {
            AddNotification("BroadcasterName", "Broadcaster name already registered");
        }

        public void BrodcastersUnavailable()
        {
            AddNotification("BroadcasterDelete", "Non-existent broadcaster for delete");
        }
    }
}
