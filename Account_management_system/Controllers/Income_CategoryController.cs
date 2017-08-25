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
    public class Income_CategoryController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /Income_Category/
        public ActionResult Index()
        {
            var tbl_income_category = db.tbl_income_category.Include(t => t.tbl_user);
            return View(tbl_income_category.ToList());
        }

        // GET: /Income_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_income_category tbl_income_category = db.tbl_income_category.Find(id);
            if (tbl_income_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_income_category);
        }

        // GET: /Income_Category/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name");
            return View();
        }

        // POST: /Income_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="category_id,category_name,user_id")] tbl_income_category tbl_income_category)
        {
            if (ModelState.IsValid)
            {
                db.tbl_income_category.Add(tbl_income_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_income_category.user_id);
            return View(tbl_income_category);
        }

        // GET: /Income_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_income_category tbl_income_category = db.tbl_income_category.Find(id);
            if (tbl_income_category == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_income_category.user_id);
            return View(tbl_income_category);
        }

        // POST: /Income_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="category_id,category_name,user_id")] tbl_income_category tbl_income_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_income_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_income_category.user_id);
            return View(tbl_income_category);
        }

        // GET: /Income_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_income_category tbl_income_category = db.tbl_income_category.Find(id);
            if (tbl_income_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_income_category);
        }

        // POST: /Income_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_income_category tbl_income_category = db.tbl_income_category.Find(id);
            db.tbl_income_category.Remove(tbl_income_category);
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
