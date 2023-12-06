using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITournamentRepository
    {
        Task<IEnumerable<Tournamnetmainmodel>> GetAllAsync();

        Task<Tournamnetmainmodel> GetAsync(int id);
        Task<bool> AnyAsync(int id);

        void Add(Tournamnetmainmodel tournament); void
        Update(Tournamnetmainmodel tournament); void
        Remove(Tournamnetmainmodel tournament);
        void EntityStateModified(Tournamnetmainmodel entity);

    }
}
