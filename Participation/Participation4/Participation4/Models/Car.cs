using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation4.Models
{
  public class Car
  {
    public string Make { get; set; }
    public string BodyType { get; set; }
    public double Miles { get; set; }
    public string Restrictions { get; set; }

    public Car( string mk, string type, double mls, string restrict)
    {
      Make = mk;
      BodyType = type;
      Miles = mls;
      Restrictions = restrict;
    }

  }
}