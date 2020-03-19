using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StatsNinja.Models;

namespace StatsNinja.Controllers
{
    public class StatisticEntriesController : Controller
    {
        private StatsNinjaDb db = new StatsNinjaDb();

        // GET: StatisticEntries
        public ActionResult Index()
        {
            var statisticEntries = db.StatisticEntries.Include(s => s.Player).Include(s => s.Season).Include(s => s.Statistic);
            return View(statisticEntries.ToList());
        }

        // GET: StatisticEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticEntry statisticEntry = db.StatisticEntries.Find(id);
            if (statisticEntry == null)
            {
                return HttpNotFound();
            }
            return View(statisticEntry);
        }

        // GET: StatisticEntries/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerName");
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonYears");
            ViewBag.StatisticId = new SelectList(db.Statistics, "StatisticId", "StatisticName");
            return View();
        }

        // POST: StatisticEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatisticEntryId,PlayerId,SeasonId,StatisticId,StatisticValue")] StatisticEntry statisticEntry)
        {
            if (ModelState.IsValid)
            {
                db.StatisticEntries.Add(statisticEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerName", statisticEntry.PlayerId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonYears", statisticEntry.SeasonId);
            ViewBag.StatisticId = new SelectList(db.Statistics, "StatisticId", "StatisticName", statisticEntry.StatisticId);
            return View(statisticEntry);
        }

        // GET: StatisticEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticEntry statisticEntry = db.StatisticEntries.Find(id);
            if (statisticEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerName", statisticEntry.PlayerId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonYears", statisticEntry.SeasonId);
            ViewBag.StatisticId = new SelectList(db.Statistics, "StatisticId", "StatisticName", statisticEntry.StatisticId);
            return View(statisticEntry);
        }

        // POST: StatisticEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatisticEntryId,PlayerId,SeasonId,StatisticId,StatisticValue")] StatisticEntry statisticEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statisticEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerName", statisticEntry.PlayerId);
            ViewBag.SeasonId = new SelectList(db.Seasons, "SeasonId", "SeasonYears", statisticEntry.SeasonId);
            ViewBag.StatisticId = new SelectList(db.Statistics, "StatisticId", "StatisticName", statisticEntry.StatisticId);
            return View(statisticEntry);
        }

        // GET: StatisticEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatisticEntry statisticEntry = db.StatisticEntries.Find(id);
            if (statisticEntry == null)
            {
                return HttpNotFound();
            }
            return View(statisticEntry);
        }

        // POST: StatisticEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatisticEntry statisticEntry = db.StatisticEntries.Find(id);
            db.StatisticEntries.Remove(statisticEntry);
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
