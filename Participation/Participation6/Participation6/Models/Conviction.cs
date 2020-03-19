using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation6.Models
{
  public class Conviction
  {
    public int ConvictionID { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public DateTime ConvictionDate { get; set; }
    public int InmateId { get; set; }
    public Inmate Inmate { get; set; }
  }
}