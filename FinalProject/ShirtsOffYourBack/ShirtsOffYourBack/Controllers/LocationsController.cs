using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShirtsOffYourBack.Models;

namespace ShirtsOffYourBack.Controllers
{
  [Authorize]
  public class LocationsController : Controller
  {
    private ShirtsOffYourBackDb db = new ShirtsOffYourBackDb();

    [AllowAnonymous]
    // GET: Locations
    public ActionResult Index()
    {
      var locations = db.Locations.Include(l => l.Partner);
      return View(locations.ToList());
    }
    [AllowAnonymous]
    // GET: Locations/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Location location = db.Locations.Find(id);
      if (location == null)
      {
        return HttpNotFound();
      }
      return View(location);
    }

    // GET: Locations/Create
    [Authorize(Roles = "Admin")]
    public ActionResult Create()
    {
      ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name");
      return View();
    }

    // POST: Locations/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "LocationId,PartnerId,Address,City,State,Zip")] Location location)
    {
      if (ModelState.IsValid)
      {
        db.Locations.Add(location);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", location.PartnerId);
      return View(location);
    }

    // GET: Locations/Edit/5
    [Authorize(Roles = "Admin")]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Location location = db.Locations.Find(id);
      if (location == null)
      {
        return HttpNotFound();
      }
      ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", location.PartnerId);
      return View(location);
    }

    // POST: Locations/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "LocationId,PartnerId,Address,City,State,Zip")] Location location)
    {
      if (ModelState.IsValid)
      {
        db.Entry(location).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.PartnerId = new SelectList(db.Partners, "PartnerId", "Name", location.PartnerId);
      return View(location);
    }

    // GET: Locations/Delete/5
    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Location location = db.Locations.Find(id);
      if (location == null)
      {
        return HttpNotFound();
      }
      return View(location);
    }

    // POST: Locations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Location location = db.Locations.Find(id);
      db.Locations.Remove(location);
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
