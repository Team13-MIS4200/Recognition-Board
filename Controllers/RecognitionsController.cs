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
    [Authorize]
    public class RecognitionsController : Controller
    {
        private RecognitionBoardContext db = new RecognitionBoardContext();

        // GET: Recognitions
        public ActionResult Index()
        {
            return View(db.Recognitions.ToList());
        }

        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognitions recognitions = db.Recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            return View(recognitions);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Employees, "employeeID", "fullName");
            
            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recognitionID,employeeID,award,description")] Recognitions recognitions)
        {
            if (ModelState.IsValid)
            {
                Guid memberID; // create a variable to hold the guid
                Guid.TryParse(User.Identity.GetUserId(), out memberID);
                recognitions.From = memberID;
                recognitions.recognizationDate = DateTime.Now;
                db.Recognitions.Add(recognitions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recognitions);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognitions recognitions = db.Recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            return View(recognitions);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recognitionID,employeeID,award,description,recognizationDate")] Recognitions recognitions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognitions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recognitions);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognitions recognitions = db.Recognitions.Find(id);
            if (recognitions == null)
            {
                return HttpNotFound();
            }
            return View(recognitions);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognitions recognitions = db.Recognitions.Find(id);
            db.Recognitions.Remove(recognitions);
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
