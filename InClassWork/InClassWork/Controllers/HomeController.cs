using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InClassWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Action1()
        {
            var languages = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            ViewBag.LanguagesList = languages;

            return View();
        }

        public ActionResult ShowLangs()
        {
            var viewModel = new ViewModels.Home.ShowLangsViewModel(CultureInfo.GetCultures(CultureTypes.SpecificCultures));

            return View(viewModel);

        }
    }
}