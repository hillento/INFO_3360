using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShirtsOffYourBack.Models
{
  public class Partner
  {
    [Display(Name = "Partner ID")]
    public int PartnerId { get; set; }

    [Required]
    [Display(Name = "Partner")]
    [StringLength(900, MinimumLength = 2)]
    public string Name { get; set; }

    public List<Location> Locations { get; set; }
  }
}