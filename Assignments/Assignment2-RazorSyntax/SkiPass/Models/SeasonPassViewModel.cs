using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiPass.Models
{
  public class SeasonPassViewModel
  {
    public List<SeasonPass> PassList { get; set; }
    public string ResortName { get; set; }

    public SeasonPassViewModel(string resortName, List<SeasonPass> passList)
    {
      PassList = passList;
      ResortName = resortName;
    }

  }
}