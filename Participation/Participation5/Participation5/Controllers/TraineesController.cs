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
    public class TraineesController : Controller
    {
        private Participation5Context db = new Participation5Context();

        // GET: Trainees
        public ActionResult Index()
        {
            var trainees = db.Trainees.Include(t => t.FitnessStyle).Include(t => t.HealthCoach);
            return View(trainees.ToList());
        }

        // GET: Trainees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: Trainees/Create
        public ActionResult Create()
        {
            ViewBag.FitnessStyleId = new SelectList(db.FitnessStyles, "FitnessStyleId", "Title");
            ViewBag.HealthCoachId = new SelectList(db.HealthCoaches, "HealthCoachId", "FirstName");
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeId,FitnessStyleId,HealthCoachId,FirstName,LastName,Gender")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FitnessStyleId = new SelectList(db.FitnessStyles, "FitnessStyleId", "Title", trainee.FitnessStyleId);
            ViewBag.HealthCoachId = new SelectList(db.HealthCoaches, "HealthCoachId", "FirstName", trainee.HealthCoachId);
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            ViewBag.FitnessStyleId = new SelectList(db.FitnessStyles, "FitnessStyleId", "Title", trainee.FitnessStyleId);
            ViewBag.HealthCoachId = new SelectList(db.HealthCoaches, "HealthCoachId", "FirstName", trainee.HealthCoachId);
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeId,FitnessStyleId,HealthCoachId,FirstName,LastName,Gender")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FitnessStyleId = new SelectList(db.FitnessStyles, "FitnessStyleId", "Title", trainee.FitnessStyleId);
            ViewBag.HealthCoachId = new SelectList(db.HealthCoaches, "HealthCoachId", "FirstName", trainee.HealthCoachId);
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
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
