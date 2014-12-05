using ShiftBusiness.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShiftBusiness;
using ShiftBusiness.Service;

namespace ShiftManagement.Controllers
{
    public class DepartmentsController : Controller
    {
        private DepartmentService db = new DepartmentService();
        public ActionResult Index()
        {
            var list = db.List();
            return View(list);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var depart = db.Find(id);
            return View(depart);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View(new Department());
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department depart)
        {
            try
            {
                db.Insert(depart);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var depart = db.Find(id);
            return View(depart);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Department depart)
        {
            try
            {
                db.Update(depart);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var depart = db.Find(id);
            return View(depart);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Department depart)
        {
            try
            {
                db.Delete(id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
