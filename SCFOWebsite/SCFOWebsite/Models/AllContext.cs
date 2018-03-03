using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCFOWebsite.Models
{
    public class AllContext : DbContext
    {
        public AllContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new AllIntializer());
           
        }

        public System.Data.Entity.DbSet<SCFOWebsite.Models.Org> Orgs { get; set; }
        public System.Data.Entity.DbSet<SCFOWebsite.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<SCFOWebsite.Models.Ship> Ships { get; set; }
        public System.Data.Entity.DbSet<SCFOWebsite.Models.PlayerShips> playerShips { get; set; }



        public class AllIntializer : DropCreateDatabaseIfModelChanges<AllContext>
        {
            protected override void Seed(AllContext context)
            {

                context.playerShips.Add(new PlayerShips()
                {
                    shipId = 1,
                    playerId = 1,
                });

                context.Orgs.Add(new Org()
                {
                    OrgId = 9000,
                    Name = "None",
                    Members = 0,
                    Focus = "NA"
                });

                context.Orgs.Add(new Org()
                {
                    Name = "528th Fleet",
                    Members = 23,
                    Focus = "Exploration"

                });
                context.Orgs.Add(new Org()
                {
                    Name = "Star Fleet",
                    Members = 834,
                    Focus = "Mining"

                });
                context.Orgs.Add(new Org()
                {
                    Name = "The Empire",
                    Members = 160,
                    Focus = "Multi"

                });

                context.Users.Add(new User()
                {
                    orgId = 1,
                    username = "User",
                    handle = "Handle",
                    email = "email@email",
                    pwd = "123",
                    admin = true
                });

                context.Ships.Add(new Ship()
                {
                    Name = "Constellation",
                    Manufacturer = "RSI",
                    Role = "Exploration",
                    ProductionState = "Complete",
                    CargoCapacity = 175,
                    MaxCrew = 5,
                    MinCrew = 1,
                    SCMSpeed = 185,
                    ABSpeed = 950,
                    ImageName = "Constellation"
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
                    ABSpeed = 1150,
                    ImageName = "cutlass"
                });

                context.Ships.Add(new Ship()
                {
                    Name = "Aurora",
                    Manufacturer = "RSI",
                    Role = "Starter",
                    ProductionState = "Flight Ready",
                    CargoCapacity = 3,
                    MaxCrew = 1,
                    MinCrew = 1,
                    SCMSpeed = 190,
                    ABSpeed = 1000,
                    ImageName = "aurora"
                });

                context.Ships.Add(new Ship()
                {
                    Name = "Avenger",
                    Manufacturer = "Aegis",
                    Role = "Cargo",
                    ProductionState = "Update Scheduled",
                    CargoCapacity = 8,
                    MaxCrew = 1,
                    MinCrew = 1,
                    SCMSpeed = 270,
                    ABSpeed = 1230,
                    ImageName = "avenger"
                });
            }
        }
    }
}