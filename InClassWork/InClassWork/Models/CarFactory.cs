using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace InClassWork.Models
{
    public class CarFactory : DbContext
    {

        public DbSet<Car> Cars { get; set; }
        public CarFactory() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CarIntializer());
        }
    }

    public class CarIntializer : DropCreateDatabaseIfModelChanges<CarFactory>
    {
        protected override void Seed(CarFactory context)
        {
            context.Cars.Add(new Car() { Model = "Rabbit", MaxSpeed = 300 });
            context.Cars.Add(new Car() { Model = "Turtle", MaxSpeed = 150 });
        }
    }
}