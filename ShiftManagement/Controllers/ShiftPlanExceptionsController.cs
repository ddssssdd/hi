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
    public class ShiftPlanExceptionsController : Controller
    {
        private ShiftPlanService db = new ShiftPlanService();

        // GET: ShiftPlanExceptions
        public ActionResult Index()
        {
            return View(db.ShiftPlanExceptions.List());
        }

        // GET: ShiftPlanExceptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPlanException shiftPlanException = db.ShiftPlanExceptions.Find(id);
            if (shiftPlanException == null)
            {
                return HttpNotFound();
            }
            return View(shiftPlanException);
        }

        // GET: ShiftPlanExceptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftPlanExceptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShiftPlanId,Name,Description,StartDate,EndDate,UsedToWeekend,UsedToHoliday,BeginTime,EndTime")] ShiftPlanException shiftPlanException)
        {
            if (ModelState.IsValid)
            {
                db.ShiftPlanExceptions.Insert(shiftPlanException);
                
                return RedirectToAction("Index");
            }

            return View(shiftPlanException);
        }

        // GET: ShiftPlanExceptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPlanException shiftPlanException = db.ShiftPlanExceptions.Find(id);
            if (shiftPlanException == null)
            {
                return HttpNotFound();
            }
            return View(shiftPlanException);
        }

        // POST: ShiftPlanExceptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShiftPlanId,Name,Description,StartDate,EndDate,UsedToWeekend,UsedToHoliday,BeginTime,EndTime")] ShiftPlanException shiftPlanException)
        {
            if (ModelState.IsValid)
            {
                db.ShiftPlanExceptions.Update(shiftPlanException);
                return RedirectToAction("Index");
            }
            return View(shiftPlanException);
        }

        // GET: ShiftPlanExceptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftPlanException shiftPlanException = db.ShiftPlanExceptions.Find(id);
            if (shiftPlanException == null)
            {
                return HttpNotFound();
            }
            return View(shiftPlanException);
        }

        // POST: ShiftPlanExceptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftPlanException shiftPlanException = db.ShiftPlanExceptions.Find(id);
            db.ShiftPlanExceptions.Delete(id);
            
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
