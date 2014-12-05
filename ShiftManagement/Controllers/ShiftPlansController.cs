using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShiftBusiness;
using ShiftBusiness.Hospital;
using ShiftBusiness.Service;

namespace ShiftManagement.Controllers
{
    public class ShiftPlansController : Controller
    {
        private ShiftPlanService db = new ShiftPlanService();

        // GET: ShiftPlans
        public ActionResult Index()
        {
            return View(db.List());
        }

        // GET: ShiftPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPlan shiftPlan = db.Find(id);
            if (shiftPlan == null)
            {
                return HttpNotFound();
            }
            return View(shiftPlan);
        }

        // GET: ShiftPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,BeginTime,EndTime,DepartmentId")] ShiftPlan shiftPlan)
        {
            if (ModelState.IsValid)
            {
                db.Insert(shiftPlan);
                
                return RedirectToAction("Index");
            }

            return View(shiftPlan);
        }

        // GET: ShiftPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPlan shiftPlan = db.Find(id);
            if (shiftPlan == null)
            {
                return HttpNotFound();
            }
            return View(shiftPlan);
        }

        // POST: ShiftPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,BeginTime,EndTime,DepartmentId")] ShiftPlan shiftPlan)
        {
            if (ModelState.IsValid)
            {
                db.Update(shiftPlan);
                return RedirectToAction("Index");
            }
            return View(shiftPlan);
        }

        // GET: ShiftPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPlan shiftPlan = db.Find(id);
            if (shiftPlan == null)
            {
                return HttpNotFound();
            }
            return View(shiftPlan);
        }

        // POST: ShiftPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            db.Delete(id);
            
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
