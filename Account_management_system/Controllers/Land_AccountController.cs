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
    public class Land_AccountController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /Land_Account/
        public ActionResult Index()
        {
            var tbl_land_account = db.tbl_land_account.Include(t => t.tbl_customer).Include(t => t.tbl_user);
            return View(tbl_land_account.ToList());
        }

        // GET: /Land_Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_land_account tbl_land_account = db.tbl_land_account.Find(id);
            if (tbl_land_account == null)
            {
                return HttpNotFound();
            }
            return View(tbl_land_account);
        }

        // GET: /Land_Account/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.tbl_customer, "customer_id", "applicant_name");
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name");
            return View();
        }

        // POST: /Land_Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="l_id,recevier,payment_process,pay_order_no,payment_type,amount,date,year,payment_discription,user_id,customer_id")] tbl_land_account tbl_land_account)
        {
            if (ModelState.IsValid)
            {
                db.tbl_land_account.Add(tbl_land_account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.tbl_customer, "customer_id", "applicant_name", tbl_land_account.customer_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_land_account.user_id);
            return View(tbl_land_account);
        }

        // GET: /Land_Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_land_account tbl_land_account = db.tbl_land_account.Find(id);
            if (tbl_land_account == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.tbl_customer, "customer_id", "applicant_name", tbl_land_account.customer_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_land_account.user_id);
            return View(tbl_land_account);
        }

        // POST: /Land_Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="l_id,recevier,payment_process,pay_order_no,payment_type,amount,date,year,payment_discription,user_id,customer_id")] tbl_land_account tbl_land_account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_land_account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.tbl_customer, "customer_id", "applicant_name", tbl_land_account.customer_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_land_account.user_id);
            return View(tbl_land_account);
        }

        // GET: /Land_Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_land_account tbl_land_account = db.tbl_land_account.Find(id);
            if (tbl_land_account == null)
            {
                return HttpNotFound();
            }
            return View(tbl_land_account);
        }

        // POST: /Land_Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_land_account tbl_land_account = db.tbl_land_account.Find(id);
            db.tbl_land_account.Remove(tbl_land_account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Customer_penal()
        {
            return View(db.tbl_land_account.ToList());
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
