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
    public class AdminController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /Admin/
        public ActionResult Index()
        {
            var tbl_admin = db.tbl_admin.Include(t => t.tbl_user);
            return View(tbl_admin.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name");
            return View();
        }

        // POST: /Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="admin_id,employeeid,admin_name,admin_email,user_name,password,status,admin_access,admin_level,user_id")] tbl_admin tbl_admin)
        {
            if (ModelState.IsValid)
            {
                db.tbl_admin.Add(tbl_admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_admin.user_id);
            return View(tbl_admin);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_admin.user_id);
            return View(tbl_admin);
        }

        // POST: /Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="admin_id,employeeid,admin_name,admin_email,user_name,password,status,admin_access,admin_level,user_id")] tbl_admin tbl_admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_admin.user_id);
            return View(tbl_admin);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_admin tbl_admin = db.tbl_admin.Find(id);
            db.tbl_admin.Remove(tbl_admin);
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
