using BroadcastersCrossCutting.Entities;
using BroadcastersDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastersDomain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);        
        Task<List<T>> GetAllAsync();
    }
}
