using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiPass.Models
{
  public class SeasonPass
  {
    public string PassName { get; set; }
    public int Cost { get; set; }
    public string Restrictions { get; set; }
    public string Bonus { get; set; }

    public SeasonPass(string passName, int cost, string restrictions, string bonus)
    {
      PassName = passName;
      Cost = cost;
      Restrictions = restrictions;
      Bonus = bonus;
    }

  }
}