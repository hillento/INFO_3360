using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Participation3.Models;

namespace Participation3.Controllers
{
  public class MyPartyController : Controller
  {
    // GET: MyParty
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult MyGifts()
    {
      var partygiftlist = new List<Gift>
      {
        new Gift { Name = "Pokemon Cards", Price = 5.99M, StoreLocation = "Walmart" },
        new Gift { Name = "My Little Pony Surpise", Price = 3.99M, StoreLocation = "Target" },
        new Gift { Name = "Legend of Zelda", Price = 19.99M, StoreLocation = "GameStop" },
        new Gift { Name = "Gameboy Pocket", Price = 49.99M, StoreLocation = "Ebay" },
        new Gift { Name = "Socks", Price = 7.99M, StoreLocation = "Target" },
        new Gift { Name = "RPG Dice", Price = 5.99M, StoreLocation = "Barnes & Noble" }
      };
      return View(partygiftlist);
    }

    public ActionResult MyFriends()
    {
      var partyfriendlist = new List<Friend>
      {
        new Friend { FirstName = "Kodey", LastName = "Crandall", BirthDate = new DateTime(1984, 01, 09), Gender = "Male", PhoneNumber = "801-830-9575" },
        new Friend { FirstName = "Alex", LastName = "Brown", BirthDate = new DateTime(1995, 02, 21), Gender = "Male", PhoneNumber = "801-833-1664" },
        new Friend { FirstName = "Corrine", LastName = "Brown", BirthDate = new DateTime(1995, 10, 13), Gender = "Female", PhoneNumber = "801-244-4383" }
      };
      return View(partyfriendlist);
    }

    public ActionResult Details()
    {
      FriendGiftViewModel friendGiftViewModel = new FriendGiftViewModel();

      var partygiftlist = new List<Gift>
      {
        new Gift { Name = "Pokemon Cards", Price = 5.99M, StoreLocation = "Walmart" },
        new Gift { Name = "My Little Pony Surpise", Price = 3.99M, StoreLocation = "Target" },
        new Gift { Name = "Legend of Zelda", Price = 19.99M, StoreLocation = "GameStop" },
        new Gift { Name = "Gameboy Pocket", Price = 49.99M, StoreLocation = "Ebay" },
        new Gift { Name = "Socks", Price = 7.99M, StoreLocation = "Target" },
        new Gift { Name = "RPG Dice", Price = 5.99M, StoreLocation = "Barnes & Noble" }
      };

      var friends = new List<Friend>
      {
        new Friend { FirstName = "Kodey", LastName = "Crandall", BirthDate = new DateTime(1984, 01, 09), Gender = "Male", PhoneNumber = "801-830-9575" },
        new Friend { FirstName = "Alex", LastName = "Brown", BirthDate = new DateTime(1995, 02, 21), Gender = "Male", PhoneNumber = "801-833-1664" },
        new Friend { FirstName = "Corrine", LastName = "Brown", BirthDate = new DateTime(1995, 10, 13), Gender = "Female", PhoneNumber = "801-244-4383" }
      };

      friendGiftViewModel.Gifts = partygiftlist;
      friendGiftViewModel.Friends = friends;

      return View(friendGiftViewModel);

    }
    public ActionResult PartyGifts()
    {
      return PartialView();
    }

    public ActionResult PartyFriends()
    {
      return PartialView();
    }


  }
}