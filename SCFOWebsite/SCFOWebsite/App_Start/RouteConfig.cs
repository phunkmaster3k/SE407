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

            routes.MapRoute(" Organizations", "Organizations",
                new { controller = "Home", action = "Organizations" });

            routes.MapRoute(" Ships", "Ships",
                new { controller = "Home", action = "Ships" });

            routes.MapRoute(name: "ShowAll",
                url: "{ name}/{ id}-Details",
                defaults: new { controller = "Home", action = "ShowAll", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
