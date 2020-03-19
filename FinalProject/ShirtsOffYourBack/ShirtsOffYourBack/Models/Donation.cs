using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShirtsOffYourBack.Models
{
  public class Donation
  {
    public int DonationId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Donation Date")]
    public DateTime DonationDate { get; set; } = DateTime.Now;

    [Range(0.00, 9999.99)]
    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }
  }
}