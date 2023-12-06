using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Entities;
using Tournament.Data.Data;
using Tournament.Core.Repositories;
using Microsoft.EntityFrameworkCore;



namespace Tournament.Data.Repositories
{
    public class TournamentRepository: ITournamentRepository
    {
        private readonly TournamentApiContext db;

        public TournamentRepository(TournamentApiContext db)
        {
            this.db = db;
        }

        public void Add(Tournamnetmainmodel tournament)
        {
            db.Tournamnetmainmodel.Add(tournament);
        }
        public async Task<IEnumerable<Tournamnetmainmodel>> GetAllAsync()
        {
            return
            await db.Tournamnetmainmodel.ToListAsync();

            //    return includeEmployees ? await db.Tournamnetmainmodel.Include(c => c.Gamedetails).ToListAsync()
            //                                : await db.Tournamnetmainmodel.ToListAsync();

        }
        public async Task<Tournamnetmainmodel?> GetAsync(int id)
        {
            return await db.Tournamnetmainmodel.FirstOrDefaultAsync(c => c.ID == id);
        }
        public void Remove(Tournamnetmainmodel tournament)
        {
            db.Tournamnetmainmodel.Remove(tournament);
        }
        public void Update(Tournamnetmainmodel tournament)
        {
            db.Tournamnetmainmodel.Update(tournament);
        }
        public async Task<bool> AnyAsync(int id)
        {
            return await db.Tournamnetmainmodel.AnyAsync(c => c.ID == id);
        
        }
        public void EntityStateModified(Tournamnetmainmodel entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
