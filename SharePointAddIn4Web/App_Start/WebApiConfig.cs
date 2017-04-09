using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace SharePointAddIn4Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionRouteHandler();
        }
        public class SessionRouteHandler : IRouteHandler
        {
            IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
            {
                return new SessionControllerHandler(requestContext.RouteData);
            }
        }
        public class SessionControllerHandler : HttpControllerHandler, IRequiresSessionState
        {
            public SessionControllerHandler(RouteData routeData) : base(routeData) { }
        }
    }
}