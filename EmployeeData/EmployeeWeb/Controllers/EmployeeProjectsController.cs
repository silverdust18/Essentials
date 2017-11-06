using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeWeb.Models;

namespace EmployeeWeb.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private EmployeeDataEntities db = new EmployeeDataEntities();

        // GET: EmployeeProjects
        public ActionResult Index()
        {
            return View(db.EmployeeProjects.ToList());
        }

        // GET: EmployeeProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProjects.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmpId,ProjectId")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeProjects.Add(employeeProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeProject);
        }

        // GET: EmployeeProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProjects.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmpId,ProjectId")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = db.EmployeeProjects.Find(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeProject employeeProject = db.EmployeeProjects.Find(id);
            db.EmployeeProjects.Remove(employeeProject);
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
