using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_2.Context;

namespace Library_2.Controllers
{
    public class LoomsController : Controller
    {
        private LibararyDbconnect db = new LibararyDbconnect();

        // GET: Looms
        public ActionResult Index()
        {
            return View(db.Loam.ToList());
        }

        // GET: Looms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loom loom = db.Loam.Find(id);
            if (loom == null)
            {
                return HttpNotFound();
            }
            return View(loom);
        }

        // GET: Looms/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Stundets, "Id", "Name");
            ViewBag.BookId = new SelectList(db.Books, "Id", "Bookname");
            return View();
        }

        // POST: Looms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentID,BookId")] Loom loom)
        {
            if (ModelState.IsValid)
            {
                loom.Date = DateTime.Now;
                db.Loam.Add(loom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Stundets, "Id", "Name",loom.StudentID);
            ViewBag.BookId = new SelectList(db.Books, "Id", "Bookname",loom.BookId);
            return View(loom);
        }

        // GET: Looms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loom loom = db.Loam.Find(id);
            if (loom == null)
            {
                return HttpNotFound();
            }
            return View(loom);
        }

        // POST: Looms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentID,BookId,Date")] Loom loom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loom);
        }

        // GET: Looms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loom loom = db.Loam.Find(id);
            if (loom == null)
            {
                return HttpNotFound();
            }
            return View(loom);
        }

        // POST: Looms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loom loom = db.Loam.Find(id);
            db.Loam.Remove(loom);
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
