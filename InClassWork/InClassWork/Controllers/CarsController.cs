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
        // GET: Cars
        public ActionResult CarsList()
        {
            var factory = new CarFactory();
            var viewModel = new CarListViewModel(factory.Cars);

            return View(viewModel);
        }
    }
}