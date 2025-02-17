﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkoutTrackerX.Models
{
    public class WorkoutTrackerXDb : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WorkoutTrackerXDb() : base("name=WorkoutTrackerXDb")
        {
        }

    public System.Data.Entity.DbSet<WorkoutTrackerX.Models.Athlete> Athletes { get; set; }

    public System.Data.Entity.DbSet<WorkoutTrackerX.Models.WorkoutEntry> WorkoutEntries { get; set; }

    public System.Data.Entity.DbSet<WorkoutTrackerX.Models.Vehicle> Vehicles { get; set; }

    public System.Data.Entity.DbSet<WorkoutTrackerX.Models.Route> Routes { get; set; }
  }
}
