using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MarkPaemaaShowCaseEntityFramework;

namespace MarkPaemaaShowCase.Areas.Sandbox.Controllers
{
    public class TechnologiesController : Controller
    {
        private MarkPaemaaShowcaseContainer db = new MarkPaemaaShowcaseContainer();

        // GET: Sandbox/Technologies
        public ActionResult Index()
        {
            return View(db.Technologies.ToList());
        }

        // GET: Sandbox/Technologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technology technology = db.Technologies.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        // GET: Sandbox/Technologies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sandbox/Technologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechnologyId,Name,Description")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                db.Technologies.Add(technology);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technology);
        }

        // GET: Sandbox/Technologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technology technology = db.Technologies.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        // POST: Sandbox/Technologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechnologyId,Name,Description")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technology);
        }

        // GET: Sandbox/Technologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technology technology = db.Technologies.Find(id);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        // POST: Sandbox/Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Technology technology = db.Technologies.Find(id);
            db.Technologies.Remove(technology);
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
