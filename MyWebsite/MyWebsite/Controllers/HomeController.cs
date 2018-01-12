using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
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

            var html = @"https://robertsspaceindustries.com/ship-matrix";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            ViewBag.ShipName = node.Name;
            //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);

            return View();
        }
    }
}