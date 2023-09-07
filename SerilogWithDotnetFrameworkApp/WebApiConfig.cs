using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SerilogWithDotnetFrameworkApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configure your Web API routes here.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}