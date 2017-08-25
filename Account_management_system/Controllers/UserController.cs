using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Account_management_system.Models;
using System.Web.Security;
using Microsoft.Ajax.Utilities;


namespace Account_management_system.Controllers
{
    public class UserController : Controller
    {
        private AMS_dbEntities db = new AMS_dbEntities();

       
        // GET: /User/
        public ActionResult Index()
        {
            return View(db.tbl_user.ToList());
        }

        // GET: /User/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="user_id,user_name,email,mobile_numbar,present_address,parmanent_address,father_name,mother_name,user_type,photo,joining_date,gender")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                db.tbl_user.Add(tbl_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="user_id,user_name,email,mobile_numbar,present_address,parmanent_address,father_name,mother_name,user_type,photo,joining_date,gender")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            db.tbl_user.Remove(tbl_user);
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


        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registration( tbl_user user)
        {
            using(AMS_dbEntities db=new AMS_dbEntities())
            {
                if (ModelState.IsValid)
                {
                    db.tbl_user.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Error = user.user_id +" "+ user.user_name +"Account is Succesfully......!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(tbl_user usr)
        {
            using (AMS_dbEntities db = new AMS_dbEntities())
            {
                //var user = db.tbl_user.Where(m => m.user_name == usr.user_id && m.email == usr.user_id).FirstOrDefault();
                var user = db.tbl_user.Where(m => m.user_name == usr.user_name && m.email == usr.email).FirstOrDefault();
                if (user != null)
                {
                    Session["user_id"] = usr.user_id.ToString();
                    Session["user_name"] = usr.user_name.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "User name and Email is worng........!");
                }
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["user_id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public ActionResult logout()
        {
            //FormsAuthentication.SignOut();
            //Session.Abandon(); // it will clear the session at the end of request
            //return Redirect("Home");
            Session["login"] = null;
            Session.Abandon();
            return Redirect("~/Home");




        }
    }
}
