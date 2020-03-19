 using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShirtsOffYourBack.Models
{
  public class ShirtsOffYourBackDbInitializer : DropCreateDatabaseAlways<ShirtsOffYourBackDb>
  {
    protected override void Seed(ShirtsOffYourBackDb context)
    {
      context.Partners.Add(new Partner
      {
        Name = "Deseret Industries",
        Locations = new List<Location>
        {
          new Location { Address = "825 E 9400 S", City = "Sandy", State = "UT", Zip = "84094" },
          new Location { Address = "11 E 4500 S", City = "Murray", State = "UT", Zip = "84107" },
          new Location { Address = "7166 S Redwood Rd", City = "West Jordan", State = "UT", Zip = "84084" },
          new Location { Address = "2140 S 800 E", City = "Salt Lake City", State = "UT", Zip = "84106" },
          new Location { Address = "12449 Creek Meadow Rd", City = "Riverton", State = "UT", Zip = "84065" },
          new Location { Address = "1665 South Bennett Road", City = "Salt Lake City", State = "UT", Zip = "84104" },
          new Location { Address = "2994 S Glen Eagle Dr Suite A", City = "West Valley City", State = "UT", Zip = "84128" },
          new Location { Address = "435 S 500 E", City = "American Fork", State = "UT", Zip = "84003" },
          new Location { Address = "743 W 700 S", City = "Salt Lake City", State = "UT", Zip = "84104" },
          new Location { Address = "158 E Pages Ln", City = "Centerville", State = "UT", Zip = "84014" },
          new Location { Address = "1415 N State St", City = "Provo", State = "UT", Zip = "84604" },
          new Location { Address = "930 W Hill Field Rd", City = "Layton", State = "UT", Zip = "84041" },
          new Location { Address = "1575 N 30 W", City = "Tooele", State = "UT", Zip = "84074" },
          new Location { Address = "645 S 1750 W", City = "Springville", State = "UT", Zip = "84663" }
        }

      });

      context.Partners.Add(new Partner
      {
        Name = "The Road Home",
        Locations = new List<Location>
                {
                    new Location { Address = "210 S Rio Grande St", City = "Salt Lake City", State = "UT", Zip = "84101" },
                    new Location { Address = "529 9th Ave", City = "Midvale", State = "UT", Zip = "84047" }
                }
      });


      context.Partners.Add(new Partner
      {
        Name = "The Salvation Army",
        Locations = new List<Location>
                {
                    new Location { Address = "438 South 900 West", City = "Salt Lake City", State = "UT", Zip = "84104" }
                }
      });

      var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

      context.SiteRoles.Add(new SiteRole { SiteRoleName = "User" });
      context.SiteRoles.Add(new SiteRole { SiteRoleName = "Admin" });

      context.SaveChanges();

      base.Seed(context);

      var admin = new ApplicationUser { UserName = "alex@yourshirt.org", Email = "alex@yourshirt.org", SiteRoleId = 2, FirstName = "Alex", LastName = "Brown", BirthDate = new DateTime(1995, 2, 21) };
      var user1 = new ApplicationUser { UserName = "joe@gmail.com", Email = "joe@gmail.com", SiteRoleId = 1, FirstName = "Joe", LastName = "Shmoe", BirthDate = new DateTime(1982, 9, 14) };

      userManager.Create(admin, "Puddin2@");
      userManager.Create(user1, "1234567");

      roleManager.Create(new IdentityRole("Admin"));
      userManager.AddToRole(admin.Id, "Admin");

      var random = new Random();

      context.Shipments.Add(new Shipment
      {
        LabelDate = DateTime.Now.AddDays(random.Next(1, 9) * -1),
        TrackingNumber = random.Next(1000000, 100000000).ToString(),
        NumberOfShirts = random.Next(1, 10),
        Status = "Label Created"
      });

      context.Shipments.Add(new Shipment
      {
        LabelDate = DateTime.Now.AddDays(random.Next(1, 9) * -1),
        TrackingNumber = random.Next(1000000, 100000000).ToString(),
        NumberOfShirts = random.Next(1, 10),
        Status = "Shipped"
      });

      context.Donations.Add(new Donation
      {
        DonationDate = DateTime.Now.AddDays(random.Next(1, 9) * -1),
        Amount = random.Next(1, 2500)
      });
      context.Donations.Add(new Donation
      {
        DonationDate = DateTime.Now.AddDays(random.Next(1, 9) * -1),
        Amount = random.Next(1, 2500)
      });

      context.SaveChanges();

    }
  }
}