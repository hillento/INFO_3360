using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Models
{
  public class Order
  {
    public int OrderId { get; set; }

    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }
    [Required]
    [StringLength(100,MinimumLength =2)]
    public string Username { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; }
    public string Country { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public decimal Total { get; set; }
  }
}