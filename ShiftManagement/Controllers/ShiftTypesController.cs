using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShiftBusiness;
using ShiftBusiness.Hospital;
using ShiftBusiness.Service;

namespace ShiftManagement.Controllers
{
    public class ShiftTypesController : Controller
    {
        private ShiftTypeService db = new ShiftTypeService();

        // GET: ShiftTypes
        public ActionResult Index()
        {
            return View( db.List());
        }

        // GET: ShiftTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ShiftType shiftType =  db.Find(id);
            if (shiftType == null)
            {
                return HttpNotFound();
            }
            return View(shiftType);
        }

        // GET: ShiftTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,DepartmentId,BriefName")] ShiftType shiftType)
        {
            if (ModelState.IsValid)
            {
                db.Insert(shiftType);
                 
                return RedirectToAction("Index");
            }

            return View(shiftType);
        }

        // GET: ShiftTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftType shiftType =  db.Find(id);
            if (shiftType == null)
            {
                return HttpNotFound();
            }
            return View(shiftType);
        }

        // POST: ShiftTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,DepartmentId,BriefName")] ShiftType shiftType)
        {
            if (ModelState.IsValid)
            {
                db.Update(shiftType);
                 
                return RedirectToAction("Index");
            }
            return View(shiftType);
        }

        // GET: ShiftTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftType shiftType =  db.Find(id);
            if (shiftType == null)
            {
                return HttpNotFound();
            }
            return View(shiftType);
        }

        // POST: ShiftTypes/Delete/5
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
