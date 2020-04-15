using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Recognition_Board.DAL;
using Recognition_Board.Models;

namespace Recognition_Board.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private RecognitionBoardContext db = new RecognitionBoardContext();

        // GET: EmployeeDetails
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: EmployeeDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.Employees.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employeeID,firstName,lastName,phoneNumber,officeLocation,department,position,manager,hireDate")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                //employeeDetails.employeeID = Guid.NewGuid();
                Guid memberID; // create a variable to hold the guid
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                employeeDetails.email = User.Identity.Name;
                employeeDetails.employeeID = memberID;
                db.Employees.Add(employeeDetails);
                employeeDetails.hireDate = DateTime.Now;
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View("DuplicateUser");
                }
            }

            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.Employees.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);

            if (employeeDetails.employeeID == memberID)
            {
                return View(employeeDetails);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employeeID,email,firstName,lastName,phoneNumber,officeLocation,department,position,manager")] EmployeeDetails employeeDetails)
        {
            if (ModelState.IsValid)
            {
                employeeDetails.email = User.Identity.Name;
                db.Entry(employeeDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeDetails);
        }

        // GET: EmployeeDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetails employeeDetails = db.Employees.Find(id);
            if (employeeDetails == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetails);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            EmployeeDetails employeeDetails = db.Employees.Find(id);
            db.Employees.Remove(employeeDetails);
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
