using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eight_Ball_A6.Models
{
  public class AnswerDb : DbContext
  {
    public DbSet<Answer> Answers { get; set; }
  }

}