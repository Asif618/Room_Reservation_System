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
    public class RoomInformationsController : Controller
    {
        private ProjectEntities2 db = new ProjectEntities2();

        // GET: RoomInformations
        public ActionResult Index()
        {
            return View(db.RoomInformations.ToList());
        }

        // GET: RoomInformations/Details/5
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

        public ActionResult Create()
        {
            return View();
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,User_Name,Adress,Room_Name,Room_No,Start_Date,Finish_Date,Phone")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoes.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfo);
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
