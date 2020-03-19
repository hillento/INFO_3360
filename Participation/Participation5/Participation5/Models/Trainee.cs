using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation5.Models
{
  public class Trainee
  {
    public virtual int TraineeId { get; set; }
    public virtual int FitnessStyleId { get; set; }
    public virtual int HealthCoachId { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Gender { get; set; }
    public virtual FitnessStyle FitnessStyle { get; set; }
    public virtual HealthCoach HealthCoach { get; set; }

  }
}