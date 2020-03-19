using Participation10_3360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Participation10_3360.Controllers
{
    public class FileController : Controller
    {
    private UserProfilesDb db = new UserProfilesDb();
        // GET: File
        public ActionResult Index(int id)
        {
      var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}