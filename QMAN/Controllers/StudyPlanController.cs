using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QMAN.Models;

namespace QMAN.Controllers
{
    public class StudyPlanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudyPlan
        public ActionResult Index()
        {
            return View(db.StudyPlanQualifications.ToList());
        }

        // GET: StudyPlan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyPlanQualification studyPlanQualification = db.StudyPlanQualifications.Find(id);
            if (studyPlanQualification == null)
            {
                return HttpNotFound();
            }
            return View(studyPlanQualification);
        }

        // GET: StudyPlan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudyPlan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudyPlanCode,QualCode,Priority")] StudyPlanQualification studyPlanQualification)
        {
            if (ModelState.IsValid)
            {
                db.StudyPlanQualifications.Add(studyPlanQualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studyPlanQualification);
        }

        // GET: StudyPlan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyPlanQualification studyPlanQualification = db.StudyPlanQualifications.Find(id);
            if (studyPlanQualification == null)
            {
                return HttpNotFound();
            }
            return View(studyPlanQualification);
        }

        // POST: StudyPlan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudyPlanCode,QualCode,Priority")] StudyPlanQualification studyPlanQualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyPlanQualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studyPlanQualification);
        }

        // GET: StudyPlan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyPlanQualification studyPlanQualification = db.StudyPlanQualifications.Find(id);
            if (studyPlanQualification == null)
            {
                return HttpNotFound();
            }
            return View(studyPlanQualification);
        }

        // POST: StudyPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudyPlanQualification studyPlanQualification = db.StudyPlanQualifications.Find(id);
            db.StudyPlanQualifications.Remove(studyPlanQualification);
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
