using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult Page2()
        {
            ViewBag.Message = "Partie 2";

            return View();
        }

        public ActionResult Page3()
        {
            ViewBag.Message = "Partie 3";

            return View();
        }

        public ActionResult Page4()
        {
            ViewBag.Message = "Partie 4";

            return View();
        }

        public ActionResult Page5()
        {
            ViewBag.Message = "Partie 5";

            return View();
        }
    }
}