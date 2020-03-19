using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Participation6.Models;

namespace Participation6.Controllers
{
  public class ConvictionsController : Controller
  {
    private Participation6Db db = new Participation6Db();

    // GET: Convictions
    public ActionResult Index()
    {
      var inmateList = db.Convictions.Include(a => a.Inmate);
      return View(inmateList.ToList());
    }

    // GET: Convictions/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Conviction conviction = db.Convictions.Find(id);
      if (conviction == null)
      {
        return HttpNotFound();
      }
      return View(conviction);
    }

    // GET: Convictions/Create
    public ActionResult Create()
    {
      ViewBag.InmateId = new SelectList(db.Inmates, "InmateID", "FirstName");
      return View();
    }

    // POST: Convictions/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ConvictionID,Type,Description,ConvictionDate,InmateId")] Conviction conviction)
    {
      if (ModelState.IsValid)
      {
        db.Convictions.Add(conviction);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.InmateId = new SelectList(db.Inmates, "InmateID", "FirstName", conviction.InmateId);
      return View(conviction);
    }

    // GET: Convictions/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Conviction conviction = db.Convictions.Find(id);
      if (conviction == null)
      {
        return HttpNotFound();
      }
      ViewBag.InmateId = new SelectList(db.Inmates, "InmateID", "FirstName", conviction.InmateId);
      return View(conviction);
    }

    // POST: Convictions/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ConvictionID,Type,Description,ConvictionDate,InmateId")] Conviction conviction)
    {
      if (ModelState.IsValid)
      {
        db.Entry(conviction).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.InmateId = new SelectList(db.Inmates, "InmateID", "FirstName", conviction.InmateId);
      return View(conviction);
    }

    // GET: Convictions/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Conviction conviction = db.Convictions.Find(id);
      if (conviction == null)
      {
        return HttpNotFound();
      }
      return View(conviction);
    }

    // POST: Convictions/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Conviction conviction = db.Convictions.Find(id);
      db.Convictions.Remove(conviction);
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
