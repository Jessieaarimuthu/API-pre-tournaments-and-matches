using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace Tournament.Data.Data
{
    public class SeedData
    {
        private static TournamentApiContext db = null!;
        public static async Task InitAsync(TournamentApiContext context)
        {
            db = context ?? throw new ArgumentNullException(nameof(context));

            if (await db.Tournamnetmainmodel.AnyAsync()) return;

            //var games = GenerateGames();
            //await db.AddRangeAsync(games);
            //var tournament = GenerateTournament(5, games);
            //await db.AddRangeAsync(tournament);
            //await db.SaveChangesAsync();
        }
    }
}
