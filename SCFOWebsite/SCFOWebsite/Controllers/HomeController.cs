using SCFOWebsite.Models;
using SCFOWebsite.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;

namespace SCFOWebsite.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            string url = "https://robertsspaceindustries.com/comm-link/rss";

            //passing in url so i can use RRSViewModel with any feed
            var viewModel = new ViewModels.Home.RSSViewModel(url);

            return View(viewModel);
        }

        public ActionResult Feedback(string feedback)
        {

            ViewBag.feedback = feedback;
            return View();
        }




    }
}