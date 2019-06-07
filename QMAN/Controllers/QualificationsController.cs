using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QMAN;
using QMAN.Models;

namespace QMAN.Controllers
{
    public class QualificationsController : Controller
    {
        private admin_it_studies_devEntities db = new admin_it_studies_devEntities();

        // GET: qualifications1
        public ActionResult Index(string searchString, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.Code1Parm = sortOrder == "NationalCode" ? "natcode_desc" : "NationalCode";
            ViewBag.Code2Parm = sortOrder == "TafeCode" ? "tafecode_desc" : "TafeCode";

            IEnumerable<qualification> quals = db.qualification;

            if (!String.IsNullOrEmpty(searchString))
            {
                quals = db.qualification.Where(q => q.QualName.Contains(searchString) || q.NationalQualCode.Contains(searchString) || q.TafeQualCode.Contains(searchString));
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

            ViewResult vr1 = View(quals.ToList<qualification>());
            //vr1.ViewName = "Index"; // - FORCE FAILURE FOR TEST
            return vr1;
        }

        // GET: qualifications1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            qualification qualification = db.qualification.Find(id); 
            //qualification qualification = db.qualification.Include(q => q.subject_qualification.Select(sq => sq.subject)).FirstOrDefault(q => q.QualCode == id);

            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        public void Close()
        {
            db.Database.Connection.Close();
        }
        IEnumerable<competency_qualification> GetCompQualForQual(string qualCode)
        {
            return db.competency_qualification.Where(cq => cq.QualCode == qualCode).ToList<competency_qualification>();
        }

        public bool IsCompInQual(string qualCode, string nationalCompCode)
        {
            try
            {
                competency_qualification compqual = db.competency_qualification.First(cq => cq.QualCode == qualCode && cq.NationalCompCode == nationalCompCode);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public IEnumerable<competency> GetCompForQualSubject(string qualCode, string subjectCode)
        {
            IEnumerable<competency_qualification> compquals = GetCompQualForQual(qualCode).ToList();
            List<competency> retList = new List<competency>();

            foreach (var compqual in compquals)
            {
                competency comp = db.competency.Include("subject").Where(c => c.NationalCompCode == compqual.NationalCompCode).First();
                subject sub = comp.subject.FirstOrDefault(s => s.SubjectCode == subjectCode);

                if (sub != null)
                    retList.Add(comp);
            }
            
            return retList;
        }

        public competency_qualification GetCompQualForComp(string qualCode, string nationalCompCode)
        {            
            try
            {
                return db.competency_qualification.First(cq => cq.QualCode == qualCode && cq.NationalCompCode == nationalCompCode);
            }
            catch
            {
                return null;
            }
        }
            

        // GET: qualifications1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: qualifications1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QualCode,NationalQualCode,TafeQualCode,QualName,TotalUnits,CoreUnits,ElectedUnits,ReqListedElectedUnits")] qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.qualification.Add(qualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qualification);
        }

        // GET: qualifications1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qualification qualification = db.qualification.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: qualifications1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QualCode,NationalQualCode,TafeQualCode,QualName,TotalUnits,CoreUnits,ElectedUnits,ReqListedElectedUnits")] qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qualification);
        }

        // GET: qualifications1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            qualification qualification = db.qualification.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: qualifications1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            qualification qualification = db.qualification.Find(id);
            db.qualification.Remove(qualification);
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
