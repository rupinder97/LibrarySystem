﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystem;

namespace LibrarySystem.Controllers
{
    public class HeadLibrariansController : Controller
    {
        private LibrarySystemEntities2 db = new LibrarySystemEntities2();

        // GET: HeadLibrarians
        public ActionResult Index()
        {
            return View(db.HeadLibrarians.ToList());
        }

        // GET: HeadLibrarians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadLibrarian headLibrarian = db.HeadLibrarians.Find(id);
            if (headLibrarian == null)
            {
                return HttpNotFound();
            }
            return View(headLibrarian);
        }

        // GET: HeadLibrarians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeadLibrarians/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] HeadLibrarian headLibrarian)
        {
            if (ModelState.IsValid)
            {
                db.HeadLibrarians.Add(headLibrarian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headLibrarian);
        }

        // GET: HeadLibrarians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadLibrarian headLibrarian = db.HeadLibrarians.Find(id);
            if (headLibrarian == null)
            {
                return HttpNotFound();
            }
            return View(headLibrarian);
        }

        // POST: HeadLibrarians/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] HeadLibrarian headLibrarian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headLibrarian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headLibrarian);
        }

        // GET: HeadLibrarians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeadLibrarian headLibrarian = db.HeadLibrarians.Find(id);
            if (headLibrarian == null)
            {
                return HttpNotFound();
            }
            return View(headLibrarian);
        }

        // POST: HeadLibrarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeadLibrarian headLibrarian = db.HeadLibrarians.Find(id);
            db.HeadLibrarians.Remove(headLibrarian);
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
