using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Participation6.Models
{
  public class UVRegistryDbInitializer : DropCreateDatabaseAlways<Participation6Db>
  {
    protected override void Seed(Participation6Db context)
    {
      context.Inmates.Add(new Inmate
      {
        FirstName = "Alex",
        LastName = "Brown",
        City = "South Jordan",
        DateOfBirth = new DateTime(1995, 02, 21),
        Convictions = new List<Conviction>
        {
          new Conviction
          {
            Type = "Robbery",
            Description = "Stole a horse",
            ConvictionDate = new DateTime(2019,09,24),
            InmateId = 1
          },
          new Conviction
          {
          Type = "Loitering",
          Description = "Standing a round",
           ConvictionDate = new DateTime(2017,09,28),
            InmateId = 1
          }
        }
      });

      context.Inmates.Add(new Inmate
      {
        FirstName = "Corrine",
        LastName = "Brown",
        City = "South Jordan",
        DateOfBirth = new DateTime(1995, 10, 13),

        Convictions = new List<Conviction>
        {
          new Conviction
          {
            Type = "Murder",
            Description = "Killed her husband Alex",
            ConvictionDate = new DateTime(2020,02,21),
            InmateId = 1
          },
          new Conviction
          {
          Type = "Speeding",
          Description = "90 in a 30",
           ConvictionDate = new DateTime(2018,09,28),
            InmateId = 1
          }
        }
      });

      context.Inmates.Add(new Inmate
      {
        FirstName = "Kodey",
        LastName = "Crandall",
        City = "Mapleton",
        DateOfBirth = new DateTime(1980,01,01),
        Convictions = new List<Conviction>
        {
          new Conviction
          {
            Type = "Robery",
            ConvictionDate = new DateTime(2017, 02, 10),
            Description = "Stole T.V.",
            InmateId = 1
          },
          new Conviction
          { Type = "Running",
            Description = "Supper Fast",
            ConvictionDate = new DateTime(2017, 05, 11),
            InmateId = 1
          }
        }
      });

      base.Seed(context);
    }


  }
}