using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Participation5.Models;

namespace Participation5.Controllers
{
    public class HealthCoachesController : Controller
    {
        private Participation5Context db = new Participation5Context();

        // GET: HealthCoaches
        public ActionResult Index()
        {
            return View(db.HealthCoaches.ToList());
        }

        // GET: HealthCoaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthCoach healthCoach = db.HealthCoaches.Find(id);
            if (healthCoach == null)
            {
                return HttpNotFound();
            }
            return View(healthCoach);
        }

        // GET: HealthCoaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HealthCoaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HealthCoachId,FirstName,LastName")] HealthCoach healthCoach)
        {
            if (ModelState.IsValid)
            {
                db.HealthCoaches.Add(healthCoach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(healthCoach);
        }

        // GET: HealthCoaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthCoach healthCoach = db.HealthCoaches.Find(id);
            if (healthCoach == null)
            {
                return HttpNotFound();
            }
            return View(healthCoach);
        }

        // POST: HealthCoaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HealthCoachId,FirstName,LastName")] HealthCoach healthCoach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthCoach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healthCoach);
        }

        // GET: HealthCoaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthCoach healthCoach = db.HealthCoaches.Find(id);
            if (healthCoach == null)
            {
                return HttpNotFound();
            }
            return View(healthCoach);
        }

        // POST: HealthCoaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthCoach healthCoach = db.HealthCoaches.Find(id);
            db.HealthCoaches.Remove(healthCoach);
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
