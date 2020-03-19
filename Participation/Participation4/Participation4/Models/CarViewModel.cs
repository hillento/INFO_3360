using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation4.Models
{
  public class CarViewModel
  {
    public string CityName { get; set; }
    public List<Car> CarList { get; set; }

    public CarViewModel(string cityname, List<Car> carlist)
    {
      CityName = cityname;
      CarList = carlist;
    }

  }
}