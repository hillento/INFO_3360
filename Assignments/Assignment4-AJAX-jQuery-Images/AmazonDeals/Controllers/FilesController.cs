using AmazonDeals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmazonDeals.Controllers
{
  public class FilesController : Controller
  {
    private AmazonDealsDb db = new AmazonDealsDb();
    // GET: Files
    public ActionResult Index(int id)
    {
      var fileToRetrieve = db.Files.Find(id);
      return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
    }

  }
}