using System.Web.Mvc;
using System.Web.Routing;

namespace MkWays
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{action}/{id}",
                new
                {
                    controller = "Home",
                    action = "Ajax",
                    id = UrlParameter.Optional
                });
        }
    }
}