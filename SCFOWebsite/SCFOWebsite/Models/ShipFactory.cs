using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SCFOWebsite.Models
{
    public class ShipFactory : DbContext
    {

        public DbSet<Ship> Ships { get; set; }
        public ShipFactory() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new ShipIntializer());
        }
    }

    public class ShipIntializer : DropCreateDatabaseIfModelChanges<ShipFactory>
    {
        protected override void Seed(ShipFactory context)
        {
            context.Ships.Add(new Ship() {
                Name = "Constellation",
                Manufacturer = "RSI",
                Role = "Exploration",
                ProductionState = "Complete",
                CargoCapacity = 175,
                MaxCrew = 5,
                MinCrew = 1,
                SCMSpeed = 185,
                ABSpeed = 950
            });
            context.Ships.Add(new Ship()
            {
                Name = "Cutlass",
                Manufacturer = "Drake",
                Role = "Pirate",
                ProductionState = "Gray Box",
                CargoCapacity = 42,
                MaxCrew = 3,
                MinCrew = 1,
                SCMSpeed = 240,
                ABSpeed = 1150
            });
        }
    }
}