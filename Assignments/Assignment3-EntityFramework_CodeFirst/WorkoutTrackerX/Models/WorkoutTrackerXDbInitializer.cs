using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkoutTrackerX.Models
{
  public class WorkoutTrackerXDbInitializer : DropCreateDatabaseAlways<WorkoutTrackerXDb>
  {
    protected override void Seed(WorkoutTrackerXDb context)
    {
      context.Athletes.Add(new Athlete { FirstName = "Rocky", LastName = "Balboa", BirthDate = new DateTime(1945, 7, 6), HomeCity = "Philadelphia, PA" });
      context.Athletes.Add(new Athlete { FirstName = "Tatyana", LastName = "McFadden", BirthDate = new DateTime(1989, 4, 21), HomeCity = "Clarksville, MD" });
      context.Athletes.Add(new Athlete { FirstName = "Ronda", LastName = "Rousey", BirthDate = new DateTime(1987, 2, 1), HomeCity = "Santa Monica, CA" });
      context.Athletes.Add(new Athlete { FirstName = "Lance", LastName = "Armstrong", BirthDate = new DateTime(1971, 9, 18), HomeCity = "Austin, TX" });
      context.Athletes.Add(new Athlete { FirstName = "Miranda", LastName = "Carfrae", BirthDate = new DateTime(1981, 4, 26), HomeCity = "Brisbane, AU" });

      context.Vehicles.Add(new Vehicle { VehicleName = "Legs", VehicleDescription = "legs" });
      context.Vehicles.Add(new Vehicle { VehicleName = "Wheelchair", VehicleDescription = "wheelchair" });
      context.Vehicles.Add(new Vehicle { VehicleName = "Road bike", VehicleDescription = "road bike" });
      context.Vehicles.Add(new Vehicle { VehicleName = "Mountain bike", VehicleDescription = "mountain bike" });

      context.Routes.Add(new Route { RouteDescription = "Run up Philadelphia Capital Steps", StartLatitude = 345.23M, StartLongitude = 324.55M, StopLatitude = 22.44M, StopLongitude = 232.25M });
      context.Routes.Add(new Route { RouteDescription = "Run at Venice Beach", StartLatitude = 345.23M, StartLongitude = 324.55M, StopLatitude = 22.44M, StopLongitude = 232.25M });
      context.Routes.Add(new Route { RouteDescription = "Biking in Nice, France", StartLatitude = 345.23M, StartLongitude = 324.55M, StopLatitude = 22.44M, StopLongitude = 232.25M });
      context.Routes.Add(new Route { RouteDescription = "Biking in Kona Ironman", StartLatitude = 345.23M, StartLongitude = 324.55M, StopLatitude = 22.44M, StopLongitude = 232.25M });
      context.Routes.Add(new Route { RouteDescription = "Boston Marathon", StartLatitude = 345.23M, StartLongitude = 324.55M, StopLatitude = 22.44M, StopLongitude = 232.25M });
      context.Routes.Add(new Route { RouteDescription = "Running in Kona Ironman", StartLatitude = 345.23M, StartLongitude = 324.55M, StopLatitude = 22.44M, StopLongitude = 232.25M });

      context.WorkoutEntries.Add(new WorkoutEntry { WorkoutEntryName = "Evening spirited run with small celebration", WorkoutEntryDateTime = new DateTime(1976, 6, 20), AthleteId = 1, VehicleId = 1, RouteId = 1 });
      context.WorkoutEntries.Add(new WorkoutEntry { WorkoutEntryName = "Boston Marathon Victory", WorkoutEntryDateTime = new DateTime(2014, 4, 21), AthleteId = 2, VehicleId = 2, RouteId = 5 });
      context.WorkoutEntries.Add(new WorkoutEntry { WorkoutEntryName = "Intense beach run", WorkoutEntryDateTime = new DateTime(2013, 5, 20), AthleteId = 3, VehicleId = 1, RouteId = 2 });
      context.WorkoutEntries.Add(new WorkoutEntry { WorkoutEntryName = "Drug fueled blast", WorkoutEntryDateTime = new DateTime(2007, 7, 15), AthleteId = 4, VehicleId = 3, RouteId = 3 });
      context.WorkoutEntries.Add(new WorkoutEntry { WorkoutEntryName = "Bike leg of Kona 2013", WorkoutEntryDateTime = new DateTime(2013, 10, 12), AthleteId = 5, VehicleId = 3, RouteId = 4 });
      context.WorkoutEntries.Add(new WorkoutEntry { WorkoutEntryName = "Run leg of Kona 2013", WorkoutEntryDateTime = new DateTime(2013, 10, 12), AthleteId = 5, VehicleId = 1, RouteId = 6 });
      base.Seed(context);
    }

  }
}