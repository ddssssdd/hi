using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShiftBusiness;
using ShiftBusiness.Ref;
using ShiftBusiness.Service;

namespace ShiftManagement.Controllers
{
    public class WorkDateTypesController : Controller
    {
        private WorkDateTypeService service = new WorkDateTypeService();

        // GET: WorkDateTypes
        public ActionResult Index()
        {
            return View(service.List());
        }

        // GET: WorkDateTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDateType workDateType = service.Find(id);
            if (workDateType == null)
            {
                return HttpNotFound();
            }
            return View(workDateType);
        }

        // GET: WorkDateTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkDateTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,BeginDate,EndDate,Year")] WorkDateType workDateType)
        {
            if (ModelState.IsValid)
            {
                service.Insert(workDateType);
                
                return RedirectToAction("Index");
            }

            return View(workDateType);
        }

        // GET: WorkDateTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDateType workDateType = service.Find(id);
            if (workDateType == null)
            {
                return HttpNotFound();
            }
            return View(workDateType);
        }

        // POST: WorkDateTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,BeginDate,EndDate,Year")] WorkDateType workDateType)
        {
            if (ModelState.IsValid)
            {
                service.Update(workDateType);
                return RedirectToAction("Index");
            }
            return View(workDateType);
        }

        // GET: WorkDateTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkDateType workDateType = service.Find(id);
            if (workDateType == null)
            {
                return HttpNotFound();
            }
            return View(workDateType);
        }

        // POST: WorkDateTypes/Delete/5
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
