using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Participation8.Models
{
  public class Event
  {
    public int EventId { get; set; }
    [Display(Name = "Event Name")]
    [StringLength(100, MinimumLength = 2)]
    public string EventName { get; set; }
    [Display(Name = "Event Date")]
    [DataType(DataType.Date)]
    public DateTime EventDateTime { get; set; }
    [Display(Name = "Event Location")]
    [StringLength(100, MinimumLength = 2)]
    public string EventLocation { get; set; }
  }
}