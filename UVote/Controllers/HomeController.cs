using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UVote.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        // Get: FAQ
        public ActionResult FAQ()
        {
            return View();
        }

        // Get: Sitemap
        public ActionResult Sitemap()
        {
            return View();
        }
    }
}