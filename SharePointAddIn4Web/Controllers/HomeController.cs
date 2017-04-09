using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharePointAddIn4Web.Controllers
{
    public class HomeController : Controller
    {
        [SharePointContextFilter]
        public ActionResult Index()
        {

            SharePointAcsContext spContext = (SharePointAcsContext)SharePointContextProvider.Current.GetSharePointContext(HttpContext);

            string accessToken = spContext.UserAccessTokenForSPHost;
            System.Web.HttpContext.Current.Session["AccessToken"] = accessToken;
            System.Web.HttpContext.Current.Session["SPHostUrl"] = spContext.SPHostUrl;
            return View();
        }
    }
}