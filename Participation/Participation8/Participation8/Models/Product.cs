using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Participation8.Models
{
  public class Product
  {
    public int ProductId { get; set; }
    [Display(Name = "Display Name")]
    [StringLength(100, ErrorMessage = "Please enter between 2 and 100 characters", MinimumLength = 2)]
    public string ProductName { get; set; }
    [Display(Name = "Minimum Bid")]
    [Range(0.00, 5000.00, ErrorMessage ="Please enter a number between 0 and 5000")]
    public decimal MinimumBid { get; set; }
  }
}