using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SCFOWebsite.Models
{
    public class OrgFactory : DbContext
    {

        public DbSet<Org> Orgs { get; set; }
        public OrgFactory() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new OrgIntializer());
        }
    }

    public class OrgIntializer : DropCreateDatabaseIfModelChanges<OrgFactory>
    {
        protected override void Seed(OrgFactory context)
        {
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
        }

    }
}