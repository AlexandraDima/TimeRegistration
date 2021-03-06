﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeRegistration.DAL;
using TimeRegistration.Models;

namespace TimeRegistration.Controllers
{
    public class HourController : Controller
    {
        private TimeRegistrationContext db = new TimeRegistrationContext();

        // GET: Hour
        public ActionResult Index()
        {
            var hours = db.Hours.Include(h => h.Employees).Include(h => h.Projects);
            return View(hours.ToList());
        }

        // GET: Hour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = db.Hours.Find(id);
            if (hour == null)
            {
                return HttpNotFound();
            }
            return View(hour);
        }

        // GET: Hour/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName");
            return View();
        }

        // POST: Hour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,EmployeeID,DateRegistration,StartingHour,EndingHour")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                db.Hours.Add(hour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", hour.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", hour.ProjectID);
            return View(hour);
        }

        // GET: Hour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = db.Hours.Find(id);
            if (hour == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", hour.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", hour.ProjectID);
            return View(hour);
        }

        // POST: Hour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,EmployeeID,DateRegistration,StartingHour,EndingHour")] Hour hour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "FirstName", hour.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "ProjectName", hour.ProjectID);
            return View(hour);
        }

        // GET: Hour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hour hour = db.Hours.Find(id);
            if (hour == null)
            {
                return HttpNotFound();
            }
            return View(hour);
        }

        // POST: Hour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hour hour = db.Hours.Find(id);
            db.Hours.Remove(hour);
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
