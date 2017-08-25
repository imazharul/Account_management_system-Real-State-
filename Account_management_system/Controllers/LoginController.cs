using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Account_management_system.Models;
using System.Web.Security;
namespace Account_management_system.Controllers
{
    public class LoginController : Controller
    {
        
        //public ActionResult Index()
        //{
        //    using(AMS_dbEntities db=new AMS_dbEntities())
        //    {
        //        return View(db.tbl_login_registration.ToList());
        //    }
        //}
        //[HttpGet]
        //public ActionResult Registration()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Registration( tbl_login_registration tbl_l_R)
        //{
        //    using(AMS_dbEntities db=new AMS_dbEntities())
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.tbl_login_registration.Add(tbl_l_R);
        //            db.SaveChanges();
        //        }
        //        ModelState.Clear();
        //        ViewBag.Error = tbl_l_R.UserName +" "+ tbl_l_R.LastName +"Account is Succesfully......!";
        //    }
        //    return View();
        //}


        //[HttpGet]
        //public ActionResult login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult login(tbl_login_registration tbl_l)
        //{
        //    using (AMS_dbEntities db = new AMS_dbEntities())
        //    {
        //        var user = db.tbl_login_registration.Where(m => m.UserName == tbl_l.UserName && m.Password == tbl_l.Password).FirstOrDefault();
                 
        //        if(tbl_l !=null)
        //        {
        //            Session["L_R_id"] = tbl_l.L_R_id.ToString();
        //            Session["UserName"] = tbl_l.UserName.ToString();
        //            return RedirectToAction("LoggedIn");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("","User name and password is worng........!");
        //        }
        //    }

        //    return View();
        //}

        //public ActionResult LoggedIn()
        //{
        //    if (Session["L_R_id"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("login");
        //    }
        //}

        //public ActionResult logout()
        //{
        //    FormsAuthentication.SignOut();
        //    Session.Abandon(); // it will clear the session at the end of request
        //   return Redirect("Home");
        //}
    }
   

}