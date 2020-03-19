using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShirtsOffYourBack.Models
{
  public class ShirtsOffYourBackDb : IdentityDbContext<ApplicationUser>
  {
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public ShirtsOffYourBackDb() : base("name=ShirtsOffYourBackDb")
    {
    }

    public static ShirtsOffYourBackDb Create()
    {
      return new ShirtsOffYourBackDb();
    }

    public System.Data.Entity.DbSet<ShirtsOffYourBack.Models.SiteRole> SiteRoles { get; set; }

    public System.Data.Entity.DbSet<ShirtsOffYourBack.Models.Donation> Donations { get; set; }

    public System.Data.Entity.DbSet<ShirtsOffYourBack.Models.Location> Locations { get; set; }

    public System.Data.Entity.DbSet<ShirtsOffYourBack.Models.Partner> Partners { get; set; }

    public System.Data.Entity.DbSet<ShirtsOffYourBack.Models.Shipment> Shipments { get; set; }
  }
}
