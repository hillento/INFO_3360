using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Eight_Ball_A6.Models
{
  public class AnswerDbInitializer : DropCreateDatabaseAlways<AnswerDb>
  {
    protected override void Seed(AnswerDb context)
    {
      context.Answers.Add(new Answer { AnswerText = "Odds are not good" });
      context.Answers.Add(new Answer { AnswerText = "No" });
      context.Answers.Add(new Answer { AnswerText = "It will pass" });
      context.Answers.Add(new Answer { AnswerText = "Cannot tell now" });
      context.Answers.Add(new Answer { AnswerText = "You are hot" });
      context.Answers.Add(new Answer { AnswerText = "Count on it" });
      context.Answers.Add(new Answer { AnswerText = "Bet on it" });
      context.Answers.Add(new Answer { AnswerText = "May be" });
      context.Answers.Add(new Answer { AnswerText = "Possibly" });
      context.Answers.Add(new Answer { AnswerText = "Ask again" });
      context.Answers.Add(new Answer { AnswerText = "No doubt" });
      context.Answers.Add(new Answer { AnswerText = "Absolutely" });
      context.Answers.Add(new Answer { AnswerText = "Very likely" });
      context.Answers.Add(new Answer { AnswerText = "Act now!" });
      context.Answers.Add(new Answer { AnswerText = "Stars say no" });
      context.Answers.Add(new Answer { AnswerText = "Can not say" });
      context.Answers.Add(new Answer { AnswerText = "Not now" });
      context.Answers.Add(new Answer { AnswerText = "Go for it!" });
      context.Answers.Add(new Answer { AnswerText = "Yes" });
      context.Answers.Add(new Answer { AnswerText = "It is okay" });
      context.SaveChanges();
      base.Seed(context);
    }
  }

}