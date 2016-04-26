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

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = DefaultController, action = DefaultAction, id = UrlParameter.Optional }
            );
        }
    }
}
