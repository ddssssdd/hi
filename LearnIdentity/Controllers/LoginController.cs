using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LearnIdentity.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public void Index()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Michael Scofield"));
            claims.Add(new Claim(ClaimTypes.Role, "Users"));
            var identity = new ClaimsIdentity(claims, "claimslogin");

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            
            System.Web.HttpContext.Current.User = principal;
            Response.Write("authen success.");
        }
    }
}