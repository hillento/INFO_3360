using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Participation11_3240.Models
{
  public class RandomKnowledgeDb : DbContext
  {
    public DbSet<Knowledge> KnowledgeList { get; set; }
  }
}