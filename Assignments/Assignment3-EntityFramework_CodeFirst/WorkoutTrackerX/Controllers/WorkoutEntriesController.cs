using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkoutTrackerX.Models;

namespace WorkoutTrackerX.Controllers
{
    public class WorkoutEntriesController : Controller
    {
        private WorkoutTrackerXDb db = new WorkoutTrackerXDb();

        // GET: WorkoutEntries
        public ActionResult Index()
        {
            var workoutEntries = db.WorkoutEntries.Include(w => w.Athlete).Include(w => w.Route).Include(w => w.Vehicle);
            return View(workoutEntries.ToList());
        }

        // GET: WorkoutEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutEntry workoutEntry = db.WorkoutEntries.Find(id);
            if (workoutEntry == null)
            {
                return HttpNotFound();
            }
            return View(workoutEntry);
        }

        // GET: WorkoutEntries/Create
        public ActionResult Create()
        {
            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "FirstName");
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteDescription");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleName");
            return View();
        }

        // POST: WorkoutEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkoutEntryId,WorkoutEntryName,WorkoutEntryDateTime,AthleteId,RouteId,VehicleId")] WorkoutEntry workoutEntry)
        {
            if (ModelState.IsValid)
            {
                db.WorkoutEntries.Add(workoutEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "FirstName", workoutEntry.AthleteId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteDescription", workoutEntry.RouteId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleName", workoutEntry.VehicleId);
            return View(workoutEntry);
        }

        // GET: WorkoutEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutEntry workoutEntry = db.WorkoutEntries.Find(id);
            if (workoutEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "FirstName", workoutEntry.AthleteId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteDescription", workoutEntry.RouteId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleName", workoutEntry.VehicleId);
            return View(workoutEntry);
        }

        // POST: WorkoutEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkoutEntryId,WorkoutEntryName,WorkoutEntryDateTime,AthleteId,RouteId,VehicleId")] WorkoutEntry workoutEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workoutEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AthleteId = new SelectList(db.Athletes, "AthleteId", "FirstName", workoutEntry.AthleteId);
            ViewBag.RouteId = new SelectList(db.Routes, "RouteId", "RouteDescription", workoutEntry.RouteId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "VehicleId", "VehicleName", workoutEntry.VehicleId);
            return View(workoutEntry);
        }

        // GET: WorkoutEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutEntry workoutEntry = db.WorkoutEntries.Find(id);
            if (workoutEntry == null)
            {
                return HttpNotFound();
            }
            return View(workoutEntry);
        }

        // POST: WorkoutEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkoutEntry workoutEntry = db.WorkoutEntries.Find(id);
            db.WorkoutEntries.Remove(workoutEntry);
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
