using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Gamemodel>> GetAllAsync();

        Task<Gamemodel> GetAsync(int id);
        Task<bool> AnyAsync(int id);

        void Add(Gamemodel game); void
        Update(Gamemodel game); void
        Remove(Gamemodel game);
        void EntityStateModified(Gamemodel entity);
    }
}
