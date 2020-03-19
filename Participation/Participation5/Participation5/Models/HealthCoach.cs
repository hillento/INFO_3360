using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation5.Models
{
  public class HealthCoach
  {
    public virtual int HealthCoachId { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
  }
}