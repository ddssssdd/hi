using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShiftBusiness;
using ShiftBusiness.Shift;
using ShiftBusiness.Service;

namespace ShiftManagement.Controllers
{
    public class EmployeeExcludesController : Controller
    {
        private EmployeeExcludeService service = new EmployeeExcludeService();

        // GET: EmployeeExcludes
        public ActionResult Index()
        {
            return View(service.List());
        }

        // GET: EmployeeExcludes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeExclude employeeExclude = service.Find(id);
            if (employeeExclude == null)
            {
                return HttpNotFound();
            }
            return View(employeeExclude);
        }

        // GET: EmployeeExcludes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeExcludes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,Reason,BeginDate,EndDate,BeginTime,EndTime,ShiftPlanId,CreatedDate,LastUpdatedDate,CreatorId")] EmployeeExclude employeeExclude)
        {
            if (ModelState.IsValid)
            {
                service.Insert(employeeExclude);
                
                return RedirectToAction("Index");
            }

            return View(employeeExclude);
        }

        // GET: EmployeeExcludes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeExclude employeeExclude = service.Find(id);
            if (employeeExclude == null)
            {
                return HttpNotFound();
            }
            return View(employeeExclude);
        }

        // POST: EmployeeExcludes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,Reason,BeginDate,EndDate,BeginTime,EndTime,ShiftPlanId,CreatedDate,LastUpdatedDate,CreatorId")] EmployeeExclude employeeExclude)
        {
            if (ModelState.IsValid)
            {
                service.Update(employeeExclude);
                
                return RedirectToAction("Index");
            }
            return View(employeeExclude);
        }

        // GET: EmployeeExcludes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeExclude employeeExclude = service.Find(id);
            if (employeeExclude == null)
            {
                return HttpNotFound();
            }
            return View(employeeExclude);
        }

        // POST: EmployeeExcludes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            service.Delete(id);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
