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
    public class SiteRolesController : Controller
    {
        private ShirtsOffYourBackDb db = new ShirtsOffYourBackDb();

        // GET: SiteRoles
        public ActionResult Index()
        {
            return View(db.SiteRoles.ToList());
        }

        // GET: SiteRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteRole siteRole = db.SiteRoles.Find(id);
            if (siteRole == null)
            {
                return HttpNotFound();
            }
            return View(siteRole);
        }

        // GET: SiteRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteRoleId,SiteRoleName")] SiteRole siteRole)
        {
            if (ModelState.IsValid)
            {
                db.SiteRoles.Add(siteRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteRole);
        }

        // GET: SiteRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteRole siteRole = db.SiteRoles.Find(id);
            if (siteRole == null)
            {
                return HttpNotFound();
            }
            return View(siteRole);
        }

        // POST: SiteRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteRoleId,SiteRoleName")] SiteRole siteRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteRole);
        }

        // GET: SiteRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteRole siteRole = db.SiteRoles.Find(id);
            if (siteRole == null)
            {
                return HttpNotFound();
            }
            return View(siteRole);
        }

        // POST: SiteRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteRole siteRole = db.SiteRoles.Find(id);
            db.SiteRoles.Remove(siteRole);
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
