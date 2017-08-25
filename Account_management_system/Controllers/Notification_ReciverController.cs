using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Account_management_system.Models;

namespace Account_management_system.Controllers
{
    public class Notification_ReciverController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /Notification_Reciver/
        public ActionResult Index()
        {
            var tbl_notification_receiver = db.tbl_notification_receiver.Include(t => t.tbl_notification);
            return View(tbl_notification_receiver.ToList());
        }

        // GET: /Notification_Reciver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_notification_receiver tbl_notification_receiver = db.tbl_notification_receiver.Find(id);
            if (tbl_notification_receiver == null)
            {
                return HttpNotFound();
            }
            return View(tbl_notification_receiver);
        }

        // GET: /Notification_Reciver/Create
        public ActionResult Create()
        {
            ViewBag.notification_id = new SelectList(db.tbl_notification, "notification_id", "sender");
            return View();
        }

        // POST: /Notification_Reciver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,receiver,status,notification_id")] tbl_notification_receiver tbl_notification_receiver)
        {
            if (ModelState.IsValid)
            {
                db.tbl_notification_receiver.Add(tbl_notification_receiver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.notification_id = new SelectList(db.tbl_notification, "notification_id", "sender", tbl_notification_receiver.notification_id);
            return View(tbl_notification_receiver);
        }

        // GET: /Notification_Reciver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_notification_receiver tbl_notification_receiver = db.tbl_notification_receiver.Find(id);
            if (tbl_notification_receiver == null)
            {
                return HttpNotFound();
            }
            ViewBag.notification_id = new SelectList(db.tbl_notification, "notification_id", "sender", tbl_notification_receiver.notification_id);
            return View(tbl_notification_receiver);
        }

        // POST: /Notification_Reciver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,receiver,status,notification_id")] tbl_notification_receiver tbl_notification_receiver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_notification_receiver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.notification_id = new SelectList(db.tbl_notification, "notification_id", "sender", tbl_notification_receiver.notification_id);
            return View(tbl_notification_receiver);
        }

        // GET: /Notification_Reciver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_notification_receiver tbl_notification_receiver = db.tbl_notification_receiver.Find(id);
            if (tbl_notification_receiver == null)
            {
                return HttpNotFound();
            }
            return View(tbl_notification_receiver);
        }

        // POST: /Notification_Reciver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_notification_receiver tbl_notification_receiver = db.tbl_notification_receiver.Find(id);
            db.tbl_notification_receiver.Remove(tbl_notification_receiver);
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
