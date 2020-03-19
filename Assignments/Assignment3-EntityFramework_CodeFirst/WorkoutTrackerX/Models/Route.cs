using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkoutTrackerX.Models
{
  public class Route
  {
    public int RouteId { get; set; }
    public string RouteDescription { get; set; }
    public decimal StartLatitude { get; set; }
    public decimal StartLongitude { get; set; }
    public decimal StopLatitude { get; set; }
    public decimal StopLongitude { get; set; }
  }
}