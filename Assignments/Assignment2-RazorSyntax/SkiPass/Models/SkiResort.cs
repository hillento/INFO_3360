using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiPass.Models
{
  public class SkiResort
  {
    public string Name { get; set; }
    public string Location { get; set; }
    public int TopElevation { get; set; }
    public int BaseElevation { get; set; }
    public int NumberOfLifts { get; set; }
    public List<SeasonPass> PassList { get; set; }

   public SkiResort(string name, string location, int topElevation, int baseElevation, int noOfLifts, List<SeasonPass> passList)
    {
      Name = name;
      Location = location;
      TopElevation = topElevation;
      BaseElevation = baseElevation;
      NumberOfLifts = noOfLifts;
      PassList = passList;
    }

  }
}