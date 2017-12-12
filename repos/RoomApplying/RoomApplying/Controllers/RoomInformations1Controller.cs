using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoomApplying.Models;

namespace RoomApplying.Controllers
{
    public class RoomInformations1Controller : Controller
    {
        private ProjectEntities2 db = new ProjectEntities2();

        // GET: RoomInformations1
        public ActionResult Index()
        {
            return View(db.RoomInformations.ToList());
        }

        // GET: RoomInformations1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            if (roomInformation == null)
            {
                return HttpNotFound();
            }
            return View(roomInformation);
        }

        // GET: RoomInformations1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomInformations1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Room_Name,Room_No,Confirm_Room")] RoomInformation roomInformation)
        {
            if (ModelState.IsValid)
            {
                db.RoomInformations.Add(roomInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomInformation);
        }

        // GET: RoomInformations1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            if (roomInformation == null)
            {
                return HttpNotFound();
            }
            return View(roomInformation);
        }

        // POST: RoomInformations1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Room_Name,Room_No,Confirm_Room")] RoomInformation roomInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomInformation);
        }

        // GET: RoomInformations1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            if (roomInformation == null)
            {
                return HttpNotFound();
            }
            return View(roomInformation);
        }

        // POST: RoomInformations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomInformation roomInformation = db.RoomInformations.Find(id);
            db.RoomInformations.Remove(roomInformation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginAdmin(Admin user)
        {

            var Details = db.Admins.SingleOrDefault(x => x.Admin_Name == user.Admin_Name && x.Password == user.Password);
            if (Details != null)
            {
                Session["id"] = Details.id.ToString();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "UserName && Password is invalid .";
            }

            return View();
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
