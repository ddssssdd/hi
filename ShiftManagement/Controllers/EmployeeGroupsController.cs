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
    public class EmployeeGroupsController : Controller
    {
        private EmployeeGroupService db = new EmployeeGroupService();

        // GET: EmployeeGroups
        public ActionResult Index()
        {
            return View(db.List());
        }

        // GET: EmployeeGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGroup employeeGroup = db.Find(id);
            if (employeeGroup == null)
            {
                return HttpNotFound();
            }
            return View(employeeGroup);
        }

        // GET: EmployeeGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedDate,LastUpdatedDate,DepartmentId,CreatorId,FormDetails")] EmployeeGroup employeeGroup)
        {
            if (ModelState.IsValid)
            {
                
                db.Insert(employeeGroup);
                
                return RedirectToAction("Index");
            }

            return View(employeeGroup);
        }

        // GET: EmployeeGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGroup employeeGroup = db.Find(id);
            if (employeeGroup == null)
            {
                return HttpNotFound();
            }
            return View(employeeGroup);
        }

        // POST: EmployeeGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedDate,LastUpdatedDate,DepartmentId,CreatorId,FormDetails")] EmployeeGroup employeeGroup)
        {
            if (ModelState.IsValid)
            {


                db.Update(employeeGroup);
                return RedirectToAction("Index");
            }
            return View(employeeGroup);
        }

        // GET: EmployeeGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeGroup employeeGroup = db.Find(id);
            if (employeeGroup == null)
            {
                return HttpNotFound();
            }
            return View(employeeGroup);
        }

        // POST: EmployeeGroups/Delete/5
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

        public JsonResult Employees(int departId,int egId)
        {
            EmployeeGroup eg = db.Find(egId);

            return Json(db.details(eg, departId), JsonRequestBehavior.AllowGet);
        }
    }
}
