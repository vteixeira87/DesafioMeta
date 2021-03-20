using Flunt.Notifications;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BroadcastersCrossCutting.Entities
{
    public abstract class BroadcastersAudit : Entity
    {
        [BsonId]
        public int Id { get; protected set; }   
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
