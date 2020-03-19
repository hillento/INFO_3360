using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
  public class MvcMusicStoreDbInitializer : DropCreateDatabaseAlways<MvcMusicStoreDb>
  {
    protected override void Seed(MvcMusicStoreDb context)
    {
      context.Artists.Add(new Artist { Name = "Al Di Meola" });
      context.Artists.Add(new Artist { Name = "Slash" });
      context.Artists.Add(new Artist { Name = "Jon Bellion" });
      context.Genres.Add(new Genre { Name = "Jazz" });
      context.Albums.Add(new Album
      {
        Artist = new Artist { Name = "Rush" },
        Genre = new Genre { Name = "Rock" },
        Price = 9.99m,
        Title = "Caravan"
      });
      context.Albums.Add(new Album
      {
        Artist = new Artist { Name = "Lorde" },
        Genre = new Genre { Name = "Alternative" },
        Price = 9.99m,
        Title = "Pure Heroine"
      });
      context.Orders.Add(new Order
      {
        OrderDate = new DateTime(2019,09,21),
        Username = "LordeFan12",
        FirstName = "Zen",
        LastName = "Kennedey",
        Address = "Test",
        City = "Test",
        State = "Test",
        PostalCode = "84095",
        Country = "USA",
        Phone = "8018888888",
        Email = "test@test.com",
        Total = 99.99m
      });
     
      base.Seed(context);
    }

  }
}