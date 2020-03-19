using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Participation11_3240.Models
{
  public class RandomKnowledgeDbInitializer : DropCreateDatabaseAlways<RandomKnowledgeDb>
  {
    protected override void Seed(RandomKnowledgeDb context)
    {
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "1 + 1 = 2" });
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "3 * 3 = 9" });
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "Austrailia lost a war against Emus." });
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "Epstein didn't kill himself." });
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "73% of statistics are made up." });
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "My dog is a Shiba Inu." });
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "Inu means dog in Japanese." });
      context.KnowledgeList.Add(new Knowledge { KnowledgeText = "My dog is cute." });
      context.SaveChanges();
      base.Seed(context);
    }
  }

}