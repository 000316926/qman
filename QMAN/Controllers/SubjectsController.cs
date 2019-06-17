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
    public class SubjectsController : Controller
    {
        private admin_it_studies_devEntities db = new admin_it_studies_devEntities();

        // GET: Subjects
        public ActionResult Index(string searchString, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "subjectcode_desc" : "";
            ViewBag.Code1Parm = sortOrder == "SubjectCode" ? "subjectcode_desc" : "SubjectCode";
            ViewBag.Code2Parm = sortOrder == "Description" ? "desccode_desc" : "Description";

            IEnumerable<subject> subs;

            if(!String.IsNullOrEmpty(searchString))
            {
                subs = db.subject.Where(s => s.SubjectCode.Contains(searchString) || s.SubjectDescription.Contains(searchString));
            }
            else
            {
                subs = db.subject;
            }

            switch(sortOrder)
            {
                case "subjectcode_desc":
                    subs = subs.OrderByDescending(s => s.SubjectCode);
                    break;
                case "desccode_desc":
                    subs = subs.OrderByDescending(s => s.SubjectDescription);
                    break;
                case "SubjectCode":
                    subs = subs.OrderBy(s => s.SubjectCode);
                    break;
                case "Description":
                    subs = subs.OrderBy(s => s.SubjectDescription);
                    break;
                default:
                    subs = subs.OrderBy(s => s.SubjectCode);
                    break;
            }

            ViewResult vr1 = View(subs.ToList<subject>());
            return vr1;
        }

        // GET: Subjects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectCode,SubjectDescription")] subject subject)
        {
            if (ModelState.IsValid)
            {
                //db.subject.Add(subject);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectCode,SubjectDescription")] subject subject)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(subject).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subject subject = db.subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //subject subject = db.subject.Find(id);
            //db.subject.Remove(subject);
            //db.SaveChanges();
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
