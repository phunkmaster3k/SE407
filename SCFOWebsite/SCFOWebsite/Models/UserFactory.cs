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
            Database.SetInitializer(new UserIntializer());
        }
    }

    public class UserIntializer : DropCreateDatabaseIfModelChanges<UserFactory>
    {
        protected override void Seed(UserFactory context)
        {
            context.Users.Add(new User()
            {
                orgId = 1,
                username = "User",
                handle = "Handle",
                email = "email@email",
                pwd = "123",
                admin = true
            });
        }
    }
}