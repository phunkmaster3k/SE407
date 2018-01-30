using InClassWork.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InClassWork.ViewModels.Home
{
    public class CarListViewModel
    {
        public IEnumerable<SelectListItem> CarsList { get; private set; }

        public Car FasterCar { get; set; }

        public CarListViewModel(IEnumerable<Car> cars)
        {
            CarsList = cars.Select(c => new SelectListItem() { Text = c.Model });
            FasterCar = cars.OrderByDescending(c => c.MaxSpeed).FirstOrDefault();
        }
    }
}