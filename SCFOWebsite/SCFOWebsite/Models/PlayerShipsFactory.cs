using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SCFOWebsite.Models
{
    public class PlayerShipsFactory : DbContext
    {

        public DbSet<PlayerShips> playerShips { get; set; }
        public PlayerShipsFactory() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new PlayerShipsIntializer());
        }
    }

    public class PlayerShipsIntializer : DropCreateDatabaseIfModelChanges<PlayerShipsFactory>
    {
        protected override void Seed(PlayerShipsFactory context)
        {
            context.playerShips.Add(new PlayerShips()
            {
                shipId = 1,
                playerId = 1,
            });
            
        }

    }
}