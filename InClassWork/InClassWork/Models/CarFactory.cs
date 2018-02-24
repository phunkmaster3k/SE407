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
        public CarFactory()// : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CarIntializer());
        }
    }

    public class CarIntializer : DropCreateDatabaseIfModelChanges<CarFactory>
    {
        protected override void Seed(CarFactory context)
        {
            context.Cars.Add(new Car()
            {
                Model = "Conny",
                MaxSpeed = 300,
                ImageName = "Conny"
            });

            context.Cars.Add(new Car()
            {
                Model = "Avenger",
                MaxSpeed = 150,
                ImageName = "Avenger"
            });

            context.Cars.Add(new Car()
            {
                Model = "Aurora",
                MaxSpeed = 150,
                ImageName = "Aurora"
            });

            context.Cars.Add(new Car()
            {
                Model = "Cutlass",
                MaxSpeed = 150,
                ImageName = "Cutlass"
            });
        }
    }
}