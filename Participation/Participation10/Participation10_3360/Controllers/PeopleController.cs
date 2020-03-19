using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Participation10_3360.Models;

namespace Participation10_3360.Controllers
{
  [Authorize]
  public class PeopleController : Controller
  {
    private UserProfilesDb db = new UserProfilesDb();

    // GET: People
    public ActionResult Index()
    {
      return View(db.People.ToList());
    }

    // GET: People/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Person person = db.People.Include(x => x.Files).SingleOrDefault(x => x.PersonId == id);
      if (person == null)
      {
        return HttpNotFound();
      }
      return View(person);
    }

    // GET: People/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: People/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName")] Person person, HttpPostedFileBase upload)
    {
      try
      {
        if (ModelState.IsValid)
        {
          if (upload != null && upload.ContentLength > 0)
          {
            var photo = new File
            {
              FileName = System.IO.Path.GetFileName(upload.FileName),
              FileType = FileType.Photo,
              ContentType = upload.ContentType
            };

            using (var reader = new System.IO.BinaryReader(upload.InputStream))
            {
              photo.Content = reader.ReadBytes(upload.ContentLength);
            }
            person.Files = new List<File> { photo };
          }
          db.People.Add(person);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch (RetryLimitExceededException)
      {
        ModelState.AddModelError("", "Unable to save changes. try again.");
      }
      return View(person);
    }

    // GET: People/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Person person = db.People.Include(x => x.Files).SingleOrDefault(x => x.PersonId == id); 
      if (person == null)
      {
        return HttpNotFound();
      }
      return View(person);
    }

    // POST: People/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName")] Person person, HttpPostedFileBase upload)
    {
      var updatePerson = db.People.Find(person.PersonId);
      if (ModelState.IsValid)
      {
        try
        {
          if(upload != null && upload.ContentLength > 0)
          {
            if (updatePerson.Files.Any(x => x.FileType == FileType.Photo))
            {
              db.Files.Remove(updatePerson.Files.First(x => x.FileType == FileType.Photo));
            }
            var photo = new File {
              FileName = System.IO.Path.GetFileName(upload.FileName),
              FileType = FileType.Photo,
              ContentType = upload.ContentType
            };
            using (var reader = new System.IO.BinaryReader(upload.InputStream))
            {
              photo.Content = reader.ReadBytes(upload.ContentLength);
            }

            person.Files = new List<File> { photo };

            db.Entry(updatePerson).State = EntityState.Modified;
            db.SaveChanges();
          }
        }
        catch (RetryLimitExceededException)
        {

          ModelState.AddModelError("","Unable to add a profile Image.");
        }
        
        return RedirectToAction("Index");
      }
      return View(person);
    }

    // GET: People/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Person person = db.People.Find(id);
      if (person == null)
      {
        return HttpNotFound();
      }
      return View(person);
    }

    // POST: People/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Person person = db.People.Find(id);
      db.People.Remove(person);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
