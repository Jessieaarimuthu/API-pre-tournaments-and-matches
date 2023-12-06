using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class UoW:IUoW
    {
        private readonly TournamentApiContext db;
        public ITournamentRepository TournamentRepository { get; }

        //public ITournamentRepository TournamentRepository => tournamentRepository;
        public IGameRepository GameRepository { get; }

        //public IGameRepository GameRepository => gameRepository;
        public UoW(TournamentApiContext db, ITournamentRepository tournamentrepo, IGameRepository gameRepo)
        {
            this.db = db;
            TournamentRepository = tournamentrepo;
            GameRepository = gameRepo;
        }
        
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
