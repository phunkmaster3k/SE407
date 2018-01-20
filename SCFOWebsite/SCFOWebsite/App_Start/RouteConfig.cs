using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SCFOWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(" Organizations", "Organizations/{id}",
                new { controller = "Home", action = "Organizations", id = UrlParameter.Optional });

            routes.MapRoute(" Ships", "Ships",
                new { controller = "Home", action = "Ships" });

            routes.MapRoute( "AddShips", "AddShips", 
                new { controller = "Home", action = "AddShips" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
