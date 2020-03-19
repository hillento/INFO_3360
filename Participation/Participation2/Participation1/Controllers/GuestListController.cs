using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Participation1.Controllers
{
    public class GuestListController : Controller
    {
        // GET: GuestList
        public ActionResult Index(string gstName)
        {
      String message = HttpUtility.HtmlEncode(gstName);
      ViewBag.NewGuest = message;
            return View();
        }
    }
}