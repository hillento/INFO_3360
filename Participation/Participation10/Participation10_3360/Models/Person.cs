using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Participation10_3360.Models
{
  public class Person
  {
    public int PersonId { get; set; }
    [Required]
    [StringLength(100)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(100)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Display(Name = "Profile Creation Date")]
    [DataType(DataType.DateTime)]
    public DateTime ProfileCreationDate { get; set; }
    public ICollection<File> Files { get; set; }
  }
}