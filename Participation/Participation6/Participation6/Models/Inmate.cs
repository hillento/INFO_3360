using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation6.Models
{
  public class Inmate
  {
    public int InmateID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Conviction> Convictions { get; set; }
  }
}