﻿using System;
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
  public class PartnersController : Controller
  {
    private ShirtsOffYourBackDb db = new ShirtsOffYourBackDb();

    [AllowAnonymous]
    // GET: Partners
    public ActionResult Index()
    {
      return View(db.Partners.ToList());
    }
    [AllowAnonymous]
    // GET: Partners/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Partner partner = db.Partners.Find(id);
      if (partner == null)
      {
        return HttpNotFound();
      }
      return View(partner);
    }

    // GET: Partners/Create
    [Authorize(Roles = "Admin")]
    public ActionResult Create()
    {
      return View();
    }

    // POST: Partners/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "PartnerId,Name")] Partner partner)
    {
      if (ModelState.IsValid)
      {
        db.Partners.Add(partner);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(partner);
    }

    // GET: Partners/Edit/5
    [Authorize(Roles = "Admin")]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Partner partner = db.Partners.Find(id);
      if (partner == null)
      {
        return HttpNotFound();
      }
      return View(partner);
    }

    // POST: Partners/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "PartnerId,Name")] Partner partner)
    {
      if (ModelState.IsValid)
      {
        db.Entry(partner).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(partner);
    }

    // GET: Partners/Delete/5
    [Authorize(Roles = "Admin")]
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Partner partner = db.Partners.Find(id);
      if (partner == null)
      {
        return HttpNotFound();
      }
      return View(partner);
    }

    // POST: Partners/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Partner partner = db.Partners.Find(id);
      db.Partners.Remove(partner);
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
