using BroadcastersCrossCutting.Entities;
using BroadcastersDomain.Entities;
using BroadcastersDomain.Interfaces.Repositories;
using BroadcastersInfra.Context;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using MongoDB.Bson.Serialization.Conventions;

namespace BroadcastersInfra.Repositories
{
    public class BaseRepository<T> : Notifiable<Notification>, IBaseRepository<T> where T : BroadcastersAudit
    {
        protected IMongoCollection<T> Collection { get; }
        protected FilterDefinitionBuilder<T> Builders = Builders<T>.Filter;
        private readonly BroadcastersContext _context;

        public BaseRepository(BroadcastersContext context, string collectionName)
        {
            MapClass();          
            Collection = context.GetCollection<T>(collectionName);            
            _context = context;
        }

        public async Task InsertAsync(T entity)
        {
            SetAudit(entity, DatabaseOperationEnum.Insert); 
            
            await Collection.InsertOneAsync(entity);
        }

        public async Task InsertRangeAsync(List<T> entities)
        {
            foreach (var entity in entities)
                SetAudit(entity, DatabaseOperationEnum.Insert);

            await Collection.InsertManyAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            SetAudit(entity, DatabaseOperationEnum.Update);
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            await Collection.ReplaceOneAsync(filter, entity);
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            foreach (var entity in entities)
                await UpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            SetAudit(entity, DatabaseOperationEnum.Delete);
            var filter = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            await Collection.ReplaceOneAsync(filter, entity);
        }

        public async Task<List<T>> GetAllAsync()
            => await Collection.Find(x => !x.IsDeleted).ToListAsync();

        private void MapClass()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
            {
                BsonClassMap.RegisterClassMap<Entity>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIgnoreExtraElements(true);                   
                });
            } 
        }
         

        private void SetAudit(T entity, DatabaseOperationEnum operation)
        {
            if (!typeof(T).IsSubclassOf(typeof(BroadcastersAudit))) return;

            var utcNowAuditDate = DateTime.UtcNow;

            switch (operation)
            {
                case DatabaseOperationEnum.Insert:
                    entity.GetType().GetProperty("CreationDate").SetValue(entity, utcNowAuditDate, null);
                    entity.GetType().GetProperty("LastModificationDate").SetValue(entity, utcNowAuditDate, null);
                    break;
                case DatabaseOperationEnum.Update:
                    entity.GetType().GetProperty("LastModificationDate").SetValue(entity, utcNowAuditDate, null);
                    break;
                case DatabaseOperationEnum.Delete:
                    entity.GetType().GetProperty("DeletionDate").SetValue(entity, utcNowAuditDate, null);
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true, null);
                    break;
                default:
                    break;
            }
        }
    }
}

public enum DatabaseOperationEnum
{
    Insert = 1,
    Update = 2,
    Delete = 3
}
