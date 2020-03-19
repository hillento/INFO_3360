using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Participation5.Models
{
    public class Participation5Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Participation5Context() : base("name=Participation5Context")
        {
        }

    public System.Data.Entity.DbSet<Participation5.Models.Trainee> Trainees { get; set; }

    public System.Data.Entity.DbSet<Participation5.Models.FitnessStyle> FitnessStyles { get; set; }

    public System.Data.Entity.DbSet<Participation5.Models.HealthCoach> HealthCoaches { get; set; }
  }
}
