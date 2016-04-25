using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Railway.Web
{
    public class RouteConfig
    {
        public static string DefaultController = "Railway";
        public static string DefaultAction = "SelectRoute";

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = DefaultController, action = DefaultAction, id = UrlParameter.Optional }
            );
        }
    }
}
