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
    public class ExpenseCategoryController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

        // GET: /ExpenseCategory/
        public ActionResult Index()
        {
            return View(db.tbl_expense_category.ToList());
        }

        // GET: /ExpenseCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_expense_category tbl_expense_category = db.tbl_expense_category.Find(id);
            if (tbl_expense_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_expense_category);
        }

        // GET: /ExpenseCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ExpenseCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ex_category_id,category_name")] tbl_expense_category tbl_expense_category)
        {
            if (ModelState.IsValid)
            {
                db.tbl_expense_category.Add(tbl_expense_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_expense_category);
        }

        // GET: /ExpenseCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_expense_category tbl_expense_category = db.tbl_expense_category.Find(id);
            if (tbl_expense_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_expense_category);
        }

        // POST: /ExpenseCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ex_category_id,category_name")] tbl_expense_category tbl_expense_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_expense_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_expense_category);
        }

        // GET: /ExpenseCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_expense_category tbl_expense_category = db.tbl_expense_category.Find(id);
            if (tbl_expense_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_expense_category);
        }

        // POST: /ExpenseCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_expense_category tbl_expense_category = db.tbl_expense_category.Find(id);
            db.tbl_expense_category.Remove(tbl_expense_category);
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
