using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearnIdentity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Michael Scofield"));
            claims.Add(new Claim(ClaimTypes.Role, "Users"));
            var identity = new ClaimsIdentity(claims, "claimslogin");

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            System.Web.HttpContext.Current.User = principal;
        }
    }
}
