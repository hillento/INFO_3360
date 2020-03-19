using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Participation8.Models
{
    public class Participation8Db : IdentityDbContext<ApplicationUser>
  {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Participation8Db() : base("name=Participation8Db")
        {

        }
    public static Participation8Db Create()
    {
      return new Participation8Db();
    }

    public System.Data.Entity.DbSet<Participation8.Models.Event> Events { get; set; }

    public System.Data.Entity.DbSet<Participation8.Models.SiteRole> SiteRoles { get; set; }

    public System.Data.Entity.DbSet<Participation8.Models.Product> Products { get; set; }
  }

}
