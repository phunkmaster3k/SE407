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

        public ActionResult Organizations(string id)
        {

            var text = "";
            if (id != null )
            {
                if (id.Equals("ALL")) { text = id + " Orgs"; }
                else {
                    //placeholder for database getbyid
                    text = "Org with id " + id;
                }
            }
            ViewBag.TableTitle = text;
            // this will come from user later
            ViewBag.userId = 1;
            return View();
        }

        public ActionResult Ships()
        {
            ViewBag.Message = "Ships";
            return View();
        }

        public ActionResult AddShips(string price, string lbShips)
        {

            var viewModel = new ViewModels.Home.ShipsViewModel();

            //not putting these in the model for now, will change where they come from later when the DB gets implemented
            ViewBag.shipname = lbShips;
            ViewBag.shipprice = price;

            return View(viewModel);
        }

       


    }
}