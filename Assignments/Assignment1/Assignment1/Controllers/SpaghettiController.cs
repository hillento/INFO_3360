using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class SpaghettiController : Controller
    {
        // GET: Spaghetti
        public ActionResult Index(string sauce)
        {
      string message = HttpUtility.HtmlEncode(sauce);
      ViewBag.sauce = message;
            return View();
        }
    }
}