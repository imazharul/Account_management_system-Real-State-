using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Account_management_system.Models;
using Account_management_system.User_demu_Report;
using CrystalDecisions.CrystalReports.Engine;

namespace Account_management_system.Controllers
{
    public class Customer_ReportController : Controller
    {
        private AMS_dbEntities db=new AMS_dbEntities();
        // GET: /Customer_Report/
        public ActionResult Index()
        { 
            return View(db.tbl_land_account.ToList());
        }


        public ActionResult Exportuser()
        {
            List<tbl_land_account> alluser = new List<tbl_land_account>();
            alluser = db.tbl_land_account.ToList();
            ReportDocument rd=new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/User_demu_Report"), "CrystalReport_Customer_info.rpt"));

            rd.SetDataSource(alluser);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Customer_info.pdf");
        }


	}
}