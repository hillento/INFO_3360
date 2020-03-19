using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmazonDeals.Models
{
  public class Product
  {
    public int ProductId { get; set; }
    [Required]
    [Display(Name = "Product Name")]
    [StringLength(100, ErrorMessage = "Product name must be 100 characters or less.")]
    public string ProductName { get; set; }
    public DateTime EndDate { get; set; }
    public int Inventory { get; set; }
    public ICollection<File> Files { get; set; }
  }
}