using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTrackerX.Models
{
  public class Athlete
  {
    public int AthleteId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string HomeCity { get; set; }
  }
}