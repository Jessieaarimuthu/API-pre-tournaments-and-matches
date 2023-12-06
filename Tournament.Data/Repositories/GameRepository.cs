using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Tournament.Data.Repositories
{
    public class GameRepository:IGameRepository
    {
        private readonly TournamentApiContext db;

        public GameRepository(TournamentApiContext db)
        {
            this.db = db;
        }

        public void Add(Gamemodel game)
        {
            db.Gamemodel.Add(game);
        }
        public async Task<IEnumerable<Gamemodel>> GetAllAsync()
        {
            return
            await db.Gamemodel.ToListAsync();

            //    return includeEmployees ? await db.Tournamnetmainmodel.Include(c => c.Gamedetails).ToListAsync()
            //                                : await db.Tournamnetmainmodel.ToListAsync();

        }
        public async Task<Gamemodel?> GetAsync(int id)
        {
            return await db.Gamemodel.FirstOrDefaultAsync(c => c.ID == id);
        }
        public void Remove(Gamemodel game)
        {
            db.Gamemodel.Remove(game);
        }
        public void Update(Gamemodel game)
        {
            db.Gamemodel.Update(game);
        }
        public async Task<bool> AnyAsync(int id)
        {
            return await db.Gamemodel.AnyAsync(c => c.ID == id);

        }
        public void EntityStateModified(Gamemodel entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
