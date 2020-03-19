using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation4.Models
{
  public class City
  {

    public string CityName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public List<Car> carList { get; set; }

    public City(string cty, string Adrs, string phn, List<Car> cars)
    {
      Address=Adrs;
      CityName = cty;
      PhoneNumber = phn;
      carList = cars;
    }
  }
}