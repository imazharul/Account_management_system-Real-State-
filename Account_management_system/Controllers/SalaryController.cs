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
    public class SalaryController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /Salary/
        public ActionResult Index()
        {
            var tbl_salary_expense = db.tbl_salary_expense.Include(t => t.tbl_user);
            return View(tbl_salary_expense.ToList());
        }

        // GET: /Salary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_salary_expense tbl_salary_expense = db.tbl_salary_expense.Find(id);
            if (tbl_salary_expense == null)
            {
                return HttpNotFound();
            }
            return View(tbl_salary_expense);
        }

        // GET: /Salary/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name");
            return View();
        }

        // POST: /Salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="salary_expense_id,employee_id,salary_type,salary_amount,user_name,date,year,user_id")] tbl_salary_expense tbl_salary_expense)
        {
            if (ModelState.IsValid)
            {
                db.tbl_salary_expense.Add(tbl_salary_expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_salary_expense.user_id);
            return View(tbl_salary_expense);
        }

        // GET: /Salary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_salary_expense tbl_salary_expense = db.tbl_salary_expense.Find(id);
            if (tbl_salary_expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_salary_expense.user_id);
            return View(tbl_salary_expense);
        }

        // POST: /Salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="salary_expense_id,employee_id,salary_type,salary_amount,user_name,date,year,user_id")] tbl_salary_expense tbl_salary_expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_salary_expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.tbl_user, "user_id", "user_name", tbl_salary_expense.user_id);
            return View(tbl_salary_expense);
        }

        // GET: /Salary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_salary_expense tbl_salary_expense = db.tbl_salary_expense.Find(id);
            if (tbl_salary_expense == null)
            {
                return HttpNotFound();
            }
            return View(tbl_salary_expense);
        }

        // POST: /Salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_salary_expense tbl_salary_expense = db.tbl_salary_expense.Find(id);
            db.tbl_salary_expense.Remove(tbl_salary_expense);
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
