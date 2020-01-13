using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

using TimeRegistration.DAL;
using TimeRegistration.Models;

namespace TimeRegistration.Controllers
{
    public class HomeController : Controller
    {
        private TimeRegistrationContext db = new TimeRegistrationContext();

        // GET: Project
        /*
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }
       
        */

        /*
        public JsonResult Index()
        {
            List<Project> Project = new List<Project>();
            using (TimeRegistrationContext db = new TimeRegistrationContext())
            {
                Project = db.Projects.ToList();
            }

            return new JsonResult { Data = Project, JsonRequestBehavior=JsonRequestBehavior.AllowGet };
         
        }
        */
        
        public ActionResult Index() // Fetch & Show Database Data
        {
            return View();
        }


    

        //Get: /Data/
        //Fetch all projects
        public ActionResult listProjects()
        {
            var data = new List<Project>();
            using (TimeRegistrationContext db = new TimeRegistrationContext())
            {
                data = db.Projects.ToList();
            }
            //For Json to work I had to disable Lazy-loading in TimeRegistrationContext
            return Json (data, JsonRequestBehavior.AllowGet);

        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }



        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(Project project)
        {

            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
               
            }
            return Json(project);
        }
        /*
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectName,ProjectDescription,StartingDate,EndingDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }
        */
        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectName,ProjectDescription,StartingDate,EndingDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Likes()
        {
           

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}