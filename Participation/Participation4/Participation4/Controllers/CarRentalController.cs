using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Participation4.Models;

namespace Participation4.Controllers
{
    public class CarRentalController : Controller
    {

    List<City> cityList;

    protected override void Initialize(RequestContext requestContext)
    {
      base.Initialize(requestContext);
      cityList = new List<City>();
      var carList = new List<Car>
      {
        new Car("Nissan", "Sedan", 34546, "None"),
        new Car("Nissan", "Truck", 4555, "None"),
        new Car("Nissan", "Sport", 18457, "None"),
        new Car("Honda", "Sedan", 10244, "None"),
        new Car("Honda", "Truck", 7854, "None"),
        new Car("Honda", "Sport", 6831, "None"),
      };

      cityList.Add(new City("Orem", "800 West University Parkway", "801-863-5443", carList));
      cityList.Add(new City("Springville", "5460 East State Street", "801-863-5444", carList));
      cityList.Add(new City("Lehi", "100 West 200 East", "801-863-5445", carList));
      cityList.Add(new City("Provo", "777 Lucky Way", "801-863-5446", carList));
    }


    // GET: CarRental
    public ActionResult Index()
        {
            return View(cityList);
        }

    public ActionResult CarOptions(string city)
    {
      List<Car> carList = null;
      foreach (City cty in cityList)
      {
        if(cty.CityName == city)
        {
          carList = cty.carList;
          CarViewModel model = new CarViewModel(city, carList);
          return View(model);
        }
      }    
      return View("NoCarsFoundError");
    }
    public ActionResult NoCarsFoundError()
    {
      return View();
    }

    }
}