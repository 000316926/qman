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
        public ActionResult Index()
        {
            return View(db.Qualifications.ToList());
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
