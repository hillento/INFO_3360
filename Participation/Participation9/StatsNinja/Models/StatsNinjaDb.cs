using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StatsNinja.Models
{
    public class StatsNinjaDb : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public StatsNinjaDb() : base("name=StatsNinjaDb")
        {
        }

    public System.Data.Entity.DbSet<StatsNinja.Models.Season> Seasons { get; set; }
    public System.Data.Entity.DbSet<StatsNinja.Models.Player> Players { get; set; }
    public System.Data.Entity.DbSet<StatsNinja.Models.Statistic> Statistics { get; set; }
    public System.Data.Entity.DbSet<StatsNinja.Models.StatisticEntry> StatisticEntries { get; set; }
  }
}
