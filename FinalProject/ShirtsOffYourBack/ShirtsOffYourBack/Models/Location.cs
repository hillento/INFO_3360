using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShirtsOffYourBack.Models
{
  public class Location
  {
    public int LocationId { get; set; }
    public Partner Partner { get; set; }

    [Display(Name = "Partner")]
    public int PartnerId { get; set; }

    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    [DataType(DataType.PostalCode)]
    public string Zip { get; set; }
  }
}