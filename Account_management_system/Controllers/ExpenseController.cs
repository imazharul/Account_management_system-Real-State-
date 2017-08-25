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
    public class ExpenseController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /Expense/
        public ActionResult Index()
        {
            var tbl_expense = db.tbl_Expense.Include(t => t.tbl_expense_category).Include(t => t.tbl_user);
            return View(tbl_expense.ToList());
        }

        // GET: /Expense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Expense tbl_expense = db.tbl_Expense.Find(id);
            if (tbl_expense == null)
            {
                return HttpNotFound();
            }
            return View(tbl_expense);
        }

        // GET: /Expense/Create
        public ActionResult Create()
        {
            ViewBag.ex_category_id = new SelectList(db.tbl_expense_category, "ex_category_id", "category_name");
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name");
            return View();
        }

        // POST: /Expense/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="expense_id,employee_id,expense_category,expense_amount,data,year,expense_discription,user_id,ex_category_id")] tbl_Expense tbl_expense)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Expense.Add(tbl_expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ex_category_id = new SelectList(db.tbl_expense_category, "ex_category_id", "category_name", tbl_expense.ex_category_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_expense.user_id);
            return View(tbl_expense);
        }

        // GET: /Expense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Expense tbl_expense = db.tbl_Expense.Find(id);
            if (tbl_expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.ex_category_id = new SelectList(db.tbl_expense_category, "ex_category_id", "category_name", tbl_expense.ex_category_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_expense.user_id);
            return View(tbl_expense);
        }

        // POST: /Expense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="expense_id,employee_id,expense_category,expense_amount,data,year,expense_discription,user_id,ex_category_id")] tbl_Expense tbl_expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ex_category_id = new SelectList(db.tbl_expense_category, "ex_category_id", "category_name", tbl_expense.ex_category_id);
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_expense.user_id);
            return View(tbl_expense);
        }

        // GET: /Expense/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Expense tbl_expense = db.tbl_Expense.Find(id);
            if (tbl_expense == null)
            {
                return HttpNotFound();
            }
            return View(tbl_expense);
        }

        // POST: /Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Expense tbl_expense = db.tbl_Expense.Find(id);
            db.tbl_Expense.Remove(tbl_expense);
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
