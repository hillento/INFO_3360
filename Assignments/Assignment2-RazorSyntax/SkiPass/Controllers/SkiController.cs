using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SkiPass.Models;

namespace SkiPass.Controllers
{
    public class SkiController : Controller
    {

    List<SkiResort> resortList;

    protected override void Initialize(RequestContext requestContext)
    {
      base.Initialize(requestContext);
      resortList = new List<SkiResort>();
      var passList = new List<SeasonPass>();
      passList.Add(new SeasonPass("Adult Unlimited", 499, "No line cutting", "Unlimited use"));
      passList.Add(new SeasonPass("Adult Midweek", 299, "No weekend or holiday use", "Unlimited weekday"));
      passList.Add(new SeasonPass("VIP Pass", 685, "Makes other skiers mad", "Get to cut to front of line"));
      resortList.Add(new SkiResort("Sundance", "Utah County", 8250, 6100, 4, passList));
      resortList.Add(new SkiResort("Snowbird", "Salt Lake County", 11000, 7760, 13, passList));
      resortList.Add(new SkiResort("Alta", "Salt Lake County", 10550, 8530, 7, passList));
      resortList.Add(new SkiResort("Solitude", "Salt Lake County", 10035, 7988, 8, passList));
      resortList.Add(new SkiResort("Brighton", "Salt Lake County", 10750, 8755, 6, passList));
      resortList.Add(new SkiResort("Park City", "Summit County", 10000, 6900, 19, passList));
    }

    // GET: Ski
    public ActionResult Index()
        {
            return View();
        }
    public ActionResult Resorts()
    {
      return View(resortList);
    }
    public ActionResult SkiPassOptions(string resort)
    {
      List<SeasonPass> passList = null;
      foreach (SkiResort resort1 in resortList)
      {
        if (resort1.Name == resort)
        {
          passList = resort1.PassList;
          SeasonPassViewModel model = new SeasonPassViewModel(resort, passList);
          return View(model);
        }
      }
      ViewBag.resort = resort;
      return View("ResortNotFound");

    }
    public ActionResult ResortNotFound(string resort)
    {
      return View();
    }
  }
}