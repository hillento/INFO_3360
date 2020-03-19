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
  public class DonationsController : Controller
  {
    private ShirtsOffYourBackDb db = new ShirtsOffYourBackDb();

    // GET: Donations
    public ActionResult Index()
    {
      return View(db.Donations.ToList());
    }

    // GET: Donate
    public ActionResult Donate()
    {
      return View();
    }

    // POST: Donations/Donate
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Donate(Donation donation)
    {
      if (ModelState.IsValid)
      {
        db.Donations.Add(donation);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(donation);
    }

    // GET: Donations/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Donation donation = db.Donations.Find(id);
      if (donation == null)
      {
        return HttpNotFound();
      }
      return View(donation);
    }

    // GET: Donations/Create
    [Authorize(Roles = "Admin")]
    public ActionResult Create()
    {
      return View();
    }

    // POST: Donations/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "DonationId,DonationDate,Amount")] Donation donation)
    {
      if (ModelState.IsValid)
      {
        db.Donations.Add(donation);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(donation);
    }

    // GET: Donations/Edit/5
    [Authorize(Roles = "Admin")]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Donation donation = db.Donations.Find(id);
      if (donation == null)
      {
        return HttpNotFound();
      }
      return View(donation);
    }

    // POST: Donations/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "DonationId,DonationDate,Amount")] Donation donation)
    {
      if (ModelState.IsValid)
      {
        db.Entry(donation).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(donation);
    }

    // GET: Donations/Delete/5
    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Donation donation = db.Donations.Find(id);
      if (donation == null)
      {
        return HttpNotFound();
      }
      return View(donation);
    }

    // POST: Donations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Donation donation = db.Donations.Find(id);
      db.Donations.Remove(donation);
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
