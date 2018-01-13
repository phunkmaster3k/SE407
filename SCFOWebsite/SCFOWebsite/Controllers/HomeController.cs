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

            //foreach (SyndicationItem item in feed.Items)
            //{

                /*Console.WriteLine(item.Title.Text);
                Console.WriteLine(item.Summary.Text);
                Console.WriteLine(item.Links[0].Uri);
                if (item.Categories.Count > 0)
                {
                    Console.WriteLine(item.Categories[0].Name);
                }*/




            //}




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