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
    public class Extra_AccountController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /Extra_Account/
        public ActionResult Index()
        {
            var tbl_extra_account = db.tbl_extra_account.Include(t => t.tbl_income_category).Include(t => t.tbl_user);
            return View(tbl_extra_account.ToList());
        }

        // GET: /Extra_Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_extra_account tbl_extra_account = db.tbl_extra_account.Find(id);
            if (tbl_extra_account == null)
            {
                return HttpNotFound();
            }
            return View(tbl_extra_account);
        }

        // GET: /Extra_Account/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.tbl_income_category, "category_id", "category_name");
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name");
            return View();
        }

        // POST: /Extra_Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="income_id,payment_process,pay_order_ddno,incame_cetegory,date,year,amount,receiver_id,payment_discription,user_id,category_id")] tbl_extra_account tbl_extra_account)
        {
            if (ModelState.IsValid)
            {
                db.tbl_extra_account.Add(tbl_extra_account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.tbl_income_category, "category_id", "category_name", tbl_extra_account.category_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_extra_account.user_id);
            return View(tbl_extra_account);
        }

        // GET: /Extra_Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_extra_account tbl_extra_account = db.tbl_extra_account.Find(id);
            if (tbl_extra_account == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.tbl_income_category, "category_id", "category_name", tbl_extra_account.category_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_extra_account.user_id);
            return View(tbl_extra_account);
        }

        // POST: /Extra_Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="income_id,payment_process,pay_order_ddno,incame_cetegory,date,year,amount,receiver_id,payment_discription,user_id,category_id")] tbl_extra_account tbl_extra_account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_extra_account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.tbl_income_category, "category_id", "category_name", tbl_extra_account.category_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_extra_account.user_id);
            return View(tbl_extra_account);
        }

        // GET: /Extra_Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_extra_account tbl_extra_account = db.tbl_extra_account.Find(id);
            if (tbl_extra_account == null)
            {
                return HttpNotFound();
            }
            return View(tbl_extra_account);
        }

        // POST: /Extra_Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_extra_account tbl_extra_account = db.tbl_extra_account.Find(id);
            db.tbl_extra_account.Remove(tbl_extra_account);
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
