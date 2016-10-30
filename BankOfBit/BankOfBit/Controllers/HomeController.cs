using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankOfBit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Online Banking for the Bank of BIT Clients";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bank of BIT Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Find our Contact Information here.";

            return View();
        }
    }
}
