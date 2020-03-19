using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTrackerX.Models
{
  public class WorkoutEntry
  {
    public int WorkoutEntryId { get; set; }
    public string WorkoutEntryName { get; set; }
    public DateTime WorkoutEntryDateTime { get; set; }
    public int AthleteId { get; set; }
    public int RouteId { get; set; }
    public int VehicleId { get; set; }
    public Athlete Athlete { get; set; }
    public Vehicle Vehicle { get; set; }
    public Route Route { get; set; }
  }
}