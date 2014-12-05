using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize(Roles="Users")]
        public ActionResult Index()
        {
            var name = User.Identity.Name;
            var isAuthenticated = User.Identity.IsAuthenticated;
            ViewBag.islogin = isAuthenticated;
            ViewBag.username = name;
            return View();
        }
        [Authorize(Roles="Managers")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}