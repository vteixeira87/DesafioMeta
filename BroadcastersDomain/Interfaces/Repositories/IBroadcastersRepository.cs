using BroadcastersDomain.Entities;
using System.Threading.Tasks;

namespace BroadcastersDomain.Interfaces.Repositories
{
    public interface IBroadcastersRepository : IBaseRepository<Broadcasters>
    {
        Task<Broadcasters> GetByNameAsync(string name);
        Task<Broadcasters> GetByIdAsync(string id);
    }
}
