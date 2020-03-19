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
    public class FitnessStylesController : Controller
    {
        private Participation5Context db = new Participation5Context();

        // GET: FitnessStyles
        public ActionResult Index()
        {
            return View(db.FitnessStyles.ToList());
        }

        // GET: FitnessStyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessStyle fitnessStyle = db.FitnessStyles.Find(id);
            if (fitnessStyle == null)
            {
                return HttpNotFound();
            }
            return View(fitnessStyle);
        }

        // GET: FitnessStyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FitnessStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FitnessStyleId,Title,Description")] FitnessStyle fitnessStyle)
        {
            if (ModelState.IsValid)
            {
                db.FitnessStyles.Add(fitnessStyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fitnessStyle);
        }

        // GET: FitnessStyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessStyle fitnessStyle = db.FitnessStyles.Find(id);
            if (fitnessStyle == null)
            {
                return HttpNotFound();
            }
            return View(fitnessStyle);
        }

        // POST: FitnessStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FitnessStyleId,Title,Description")] FitnessStyle fitnessStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fitnessStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fitnessStyle);
        }

        // GET: FitnessStyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FitnessStyle fitnessStyle = db.FitnessStyles.Find(id);
            if (fitnessStyle == null)
            {
                return HttpNotFound();
            }
            return View(fitnessStyle);
        }

        // POST: FitnessStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FitnessStyle fitnessStyle = db.FitnessStyles.Find(id);
            db.FitnessStyles.Remove(fitnessStyle);
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
