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
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            List<SyndicationItem> items = feed.Items.ToList();

            ViewBag.RSSList = items;

            return View();
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
            List<string> ships = new List<string>();
            ships.Add("Aurora MR");
            ships.Add("Constellation Aquila");
            ships.Add("Avenger Titan");
            ships.Add("Hurricane");
            ships.Add("Reclaimer");

            ViewBag.ships = ships;
            ViewBag.shipname = lbShips;
            ViewBag.shipprice = price;

            return View();
        }

       
        




    }
}