using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACSAdminWeb.Models;

namespace ACSAdminWeb.Controllers
{
    public class AttendanceController : Controller
    {
        //
        // GET: /Attendance/

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                //ViewBag.Message = "Welcome to ACS Admin";
                return View();
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        [HttpPost]
        public void ShowGenericRptInNewWin(string FromDate, string ToDate, string AttnType)
        {
            UserAuthentication userAuth = new UserAuthentication();

            this.HttpContext.Session["rptEmployeeId"] = userAuth.GetUserID(User.Identity.Name);

            this.HttpContext.Session["rptFromDate"] = FromDate;
            this.HttpContext.Session["rptToDate"] = ToDate;
            this.HttpContext.Session["rptType"] = "Attendance";
            this.HttpContext.Session["rptSelectType"] = "";
            this.HttpContext.Session["rptYear"] = "";
            
            if (AttnType=="1")
            {
                this.HttpContext.Session["ReportName"] = "rptInOutDetail.rpt";
                AttendanceInOutDetails attendanceInOutDetails = new AttendanceInOutDetails();
                this.HttpContext.Session["rptSource"] = attendanceInOutDetails.AttendanceInOutRpTs;
            }
            else
            {
                if (AttnType == "2")
                {
                    this.HttpContext.Session["ReportName"] = "rptAttendanceDetail.rpt";
                }
                else
                {
                    this.HttpContext.Session["ReportName"] = "rptAttendanceSummary.rpt";
                }
                AttendanceDetails attendanceDetails = new AttendanceDetails();
                this.HttpContext.Session["rptSource"] = attendanceDetails.attnDT;
            }
        }
    }
}
