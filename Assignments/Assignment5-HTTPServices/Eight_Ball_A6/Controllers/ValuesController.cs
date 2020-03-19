using Eight_Ball_A6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eight_Ball_A6.Controllers
{
  public class ValuesController : ApiController
  {

    AnswerDb db = new AnswerDb();
    // GET api/values
    public IHttpActionResult Get()
    {
      var answer = db.Answers.OrderBy(a => System.Guid.NewGuid()).First().AnswerText;
      return Json(answer);
    }

    // POST api/values
    public void Post([FromBody]string value)
    {
      db.Answers.Add(new Answer { AnswerText = value });
      db.SaveChanges();
    }

  }
}
