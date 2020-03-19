using Participation11_3240.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Participation11_3240.Controllers
{
    public class ValuesController : ApiController
    {
    RandomKnowledgeDb db = new RandomKnowledgeDb();
    // GET api/values
    public IHttpActionResult Get()
    {
      var knowledge = db.KnowledgeList.OrderBy(a => System.Guid.NewGuid()).First().KnowledgeText;
      return Json(knowledge);
    }

    // POST api/values
    public void Post([FromBody]string value)
    {
      db.KnowledgeList.Add(new Knowledge { KnowledgeText = value });
      db.SaveChanges();
    }

  }
}
