using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Participation8.Models
{
  public class Participation8DbInitializer : DropCreateDatabaseAlways<Participation8Db>
  {
    protected override void Seed(Participation8Db context)
    {
      var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      context.Events.Add(new Event { EventName = "Thanksgiving Point Golf Course", EventDateTime = new DateTime(2017, 11, 1), EventLocation = "Lehi, UT" });
      context.Events.Add(new Event { EventName = "Fly Fishing (Provo)", EventDateTime = new DateTime(2017, 11, 28), EventLocation = "Provo, UT" });
      context.Events.Add(new Event { EventName = "Tulip Festival", EventDateTime = new DateTime(2020, 04, 15), EventLocation = "Lehi, UT" });
      context.Events.Add(new Event { EventName = "Final Project Due", EventDateTime = new DateTime(2019, 12, 11), EventLocation = "Orem, UT" });

      context.SiteRoles.Add(new SiteRole {SiteRoleName = "Manager" });
      context.SiteRoles.Add(new SiteRole { SiteRoleName = "Product Editor" });

      context.Products.Add(new Product { ProductName = "Roxberry Juice", MinimumBid = 19.99m });
      context.Products.Add(new Product { ProductName = "Truewhite Toothbrush", MinimumBid = 39.0m });
      context.Products.Add(new Product { ProductName = "RPG Dice Set", MinimumBid = 12.99m });
      context.Products.Add(new Product { ProductName = "Curse of Strahd", MinimumBid = 22.00m });

      context.SaveChanges();

      base.Seed(context);

      var user = new ApplicationUser { UserName = "kodey@kodey.com", Email = "kodey@kodey.com", Birthdate = new DateTime(1985, 2, 4), SiteRoleId = 1, FirstName = "Kodey", LastName = "Crandall" };
      var user1 = new ApplicationUser { UserName = "Joe@Joe.com", Email = "Joe@Joe.com", Birthdate = new DateTime(1985, 2, 4), SiteRoleId = 2, FirstName = "Joe", LastName = "Dirt" };

      userManager.Create(user, "QW!@34er");
      userManager.Create(user1, "QW!@34er");

      roleManager.Create(new IdentityRole("canEdit"));
      userManager.AddToRole(user.Id, "canEdit");
    }

  }
}