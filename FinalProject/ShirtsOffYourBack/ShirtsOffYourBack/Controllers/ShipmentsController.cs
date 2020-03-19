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
  public class ShipmentsController : Controller
  {
    private ShirtsOffYourBackDb db = new ShirtsOffYourBackDb();

    // GET: Shipments
    public ActionResult Index()
    {
      return View(db.Shipments.ToList());
    }

    // GET: Shipments/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Shipment shipment = db.Shipments.Find(id);
      if (shipment == null)
      {
        return HttpNotFound();
      }
      return View(shipment);
    }

    // GET: Shipments/RequestLabel
    public ActionResult Ship2Us()
    {
      return View();
    }

    // POST: Shipments/Ship2Us
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Ship2Us(Shipment shipment)
    {
      if (ModelState.IsValid)
      {
        db.Shipments.Add(shipment);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(shipment);
    }

    // GET: Shipments/Create
    [Authorize(Roles = "Admin")]
    public ActionResult Create()
    {
      return View();
    }

    // POST: Shipments/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ShipmentId,LabelDate,TrackingNumber,ShirtSize,Notes,Status")] Shipment shipment)
    {
      if (ModelState.IsValid)
      {
        db.Shipments.Add(shipment);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(shipment);
    }

    // GET: Shipments/Edit/5
    [Authorize(Roles = "Admin")]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Shipment shipment = db.Shipments.Find(id);
      if (shipment == null)
      {
        return HttpNotFound();
      }
      return View(shipment);
    }

    // POST: Shipments/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ShipmentId,LabelDate,TrackingNumber,ShirtSize,Notes,Status")] Shipment shipment)
    {
      if (ModelState.IsValid)
      {
        db.Entry(shipment).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(shipment);
    }

    // GET: Shipments/Delete/5
    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Shipment shipment = db.Shipments.Find(id);
      if (shipment == null)
      {
        return HttpNotFound();
      }
      return View(shipment);
    }

    // POST: Shipments/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Shipment shipment = db.Shipments.Find(id);
      db.Shipments.Remove(shipment);
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
