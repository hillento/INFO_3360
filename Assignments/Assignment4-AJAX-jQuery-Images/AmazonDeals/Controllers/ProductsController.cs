using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmazonDeals.Models;

namespace AmazonDeals.Controllers
{
  [Authorize]
  public class ProductsController : Controller
  {
    private AmazonDealsDb db = new AmazonDealsDb();

    // GET: Products
    public ActionResult Index()
    {
      return View(db.Products.ToList());
    }

    // GET: Products/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = db.Products.Include(x => x.Files).SingleOrDefault(x => x.ProductId == id);
      if (product == null)
      {
        return HttpNotFound();
      }
      return View(product);
    }

    // GET: Products/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Products/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ProductId,ProductName,EndDate")] Product product, HttpPostedFileBase upload)
    {
      try
      {
        if (ModelState.IsValid)
        {
          if (upload != null && upload.ContentLength > 0)
          {
            var photo = new File
            {
              FileName = System.IO.Path.GetFileName(upload.FileName),
              FileType = FileType.Photo,
              ContentType = upload.ContentType
            };

            using (var reader = new System.IO.BinaryReader(upload.InputStream))
            {
              photo.Content = reader.ReadBytes(upload.ContentLength);
            }
            product.Files = new List<File> { photo };
          }

          db.Products.Add(product);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch (RetryLimitExceededException)
      {
        ModelState.AddModelError("", "Unable to save changes. try again.");
      }
      return View(product);

    }

    // GET: Products/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = db.Products.Find(id);
      if (product == null)
      {
        return HttpNotFound();
      }
      return View(product);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "ProductId,ProductName,EndDate,Inventory")] Product product)
    {
      if (ModelState.IsValid)
      {
        db.Entry(product).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(product);
    }

    // GET: Products/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = db.Products.Find(id);
      if (product == null)
      {
        return HttpNotFound();
      }
      return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Product product = db.Products.Find(id);
      db.Products.Remove(product);
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
