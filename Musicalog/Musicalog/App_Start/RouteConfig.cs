using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Musicalog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AlbumInsertOrUpdate",
                url: "InsertOrUpdate/{id}",
                defaults: new { controller = "Album", action = "InsertOrUpdate", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AlbumList",
                url: "{orderby}/{page}",
                defaults: new { controller = "Album", action = "List", orderby = UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Album", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
