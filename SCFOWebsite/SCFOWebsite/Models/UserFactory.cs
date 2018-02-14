using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace SCFOWebsite.Models
{
    public class UserFactory : DbContext
    {

        public DbSet<User> Users { get; set; }
        public UserFactory() : base("name=DefaultConnection")
        {
            //Database.SetInitializer(new ShipIntializer());
        }
    }
}