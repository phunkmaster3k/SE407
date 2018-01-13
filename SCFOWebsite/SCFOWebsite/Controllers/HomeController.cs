using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCFOWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Organizations()
        {
            ViewBag.Message = "Orgs";

            return View();
        }

        public ActionResult Ships()
        {
            ViewBag.Message = "Ships";

            return View();
        }
    }
}