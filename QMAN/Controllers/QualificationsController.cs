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
    public class QualificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Qualifications
        public ActionResult Index(string searchString, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.Code1Parm = sortOrder == "NationalCode" ? "natcode_desc" : "NationalCode";
            ViewBag.Code2Parm = sortOrder == "TafeCode" ? "tafecode_desc" : "TafeCode";

            IEnumerable<Qualification> quals = db.Qualifications;

            if (!String.IsNullOrEmpty(searchString))
            {
                quals = db.Qualifications.Where(q => q.QualName.Contains(searchString) || q.NationalQualCode.Contains(searchString) || q.TafeQualCode.Contains(searchString));                
                //quals = db.Qualifications.Where(q => q.QualName.Contains(searchString));// || q.NationalQualCode.Contains(searchString) || q.TafeQualCode.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    quals = quals.OrderByDescending(q => q.QualName);
                    break;
                case "natcode_desc":
                    quals = quals.OrderByDescending(q => q.NationalQualCode);
                    break;
                case "NationalCode":
                    quals = quals.OrderBy(q => q.NationalQualCode);
                    break;
                case "tafecode_desc":
                    quals = quals.OrderByDescending(q => q.TafeQualCode);
                    break;
                case "TafeCode":
                    quals = quals.OrderBy(q => q.TafeQualCode);
                    break;
                default:
                    quals = quals.OrderBy(q => q.QualName);
                    break;
            }

            ViewResult vr1 = View(quals.ToList<Qualification>());
            //vr1.ViewName = "Index"; // - FORCE FAILURE FOR TEST
            return vr1;
        }

        // GET: Qualifications/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // GET: Qualifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QualCode,NationalQualCode,TafeQualCode,QualName,TotalUnits,CoreUnits,ElectedUnits,ReqListedElectedUnits")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Qualifications.Add(qualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QualCode,NationalQualCode,TafeQualCode,QualName,TotalUnits,CoreUnits,ElectedUnits,ReqListedElectedUnits")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Qualification qualification = db.Qualifications.Find(id);
            db.Qualifications.Remove(qualification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSubject(string QualCode, string SubjectCode)
        {
            if (QualCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(QualCode);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        [HttpPost, ActionName("DeleteSubject")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubjectConfirmed(string QualCode, string SubjectCode)
        {
            Qualification qualification = db.Qualifications.Find(QualCode);
            SubjectQualification subject = qualification.Subjects.First(s => s.SubjectCode == SubjectCode);

            db.Qualifications.Find(QualCode).Subjects.Remove(subject);

            db.SaveChanges();
            return RedirectToAction("Edit", "Qualifications", new { id = QualCode } );
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
