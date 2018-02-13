using InClassWork.Models;
using InClassWork.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InClassWork.Controllers
{
    public class CarsController : Controller
    {
        private CarFactory Db = new CarFactory();
        // GET: Cars
        public ActionResult CarsList()
        {
            var factory = new CarFactory();
            var viewModel = new CarListViewModel(factory.Cars);

            return View(viewModel);
        }

        public ActionResult ListOfCars(string searchStr)
        {
            var factory = new CarFactory();
            IQueryable<Car> cars = factory.Cars.OrderBy(p => p.Model);

            if ( searchStr != null )
            {
                cars = cars.Where(p => p.Model.Contains(searchStr));
            }

            var carsList = cars.Take(5).ToList();

            //var cars = new CarFactory().Cars.ToList();
            
            return View(carsList);
        }

        public ActionResult Details(int id)
        {
            var factory = new CarFactory();
            Car found = factory.Cars.Where(p => p.Car_ID == id).FirstOrDefault();
            return View(found);
        }
    }
}