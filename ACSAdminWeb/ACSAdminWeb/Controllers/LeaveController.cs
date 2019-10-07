using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACSAdminWeb.Models;

namespace ACSAdminWeb.Controllers
{
    public class LeaveController : Controller
    {
        //
        // GET: /Leave/

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
        public void ShowGenericRptInNewWin(string FromDate, string ToDate, string lvYear, string lvType)
        {
            UserAuthentication userAuth = new UserAuthentication();

            this.HttpContext.Session["rptType"] = "Leave";
            this.HttpContext.Session["rptSelectType"] = lvType;
            this.HttpContext.Session["rptEmployeeId"] = userAuth.GetUserID(User.Identity.Name);
            if (lvType == "1")
            {
                this.HttpContext.Session["rptFromDate"] = "";
                this.HttpContext.Session["rptToDate"] = "";

                this.HttpContext.Session["rptYear"] = lvYear;

                this.HttpContext.Session["ReportName"] = "rptLeaveSummary.rpt";
                LeaveModel leaveModel = new LeaveModel();
                this.HttpContext.Session["rptSource"] = leaveModel.leaveDT;
            }
            else
            {
                this.HttpContext.Session["rptYear"] = "";

                this.HttpContext.Session["rptFromDate"] = FromDate;
                this.HttpContext.Session["rptToDate"] = ToDate;
                if (lvType == "2")
                {
                    this.HttpContext.Session["ReportName"] = "rptLeaveDetail.rpt";
                    LeaveModel leaveModel = new LeaveModel();
                    this.HttpContext.Session["rptSource"] = leaveModel.leaveDT;
                }
                else
                {
                    //this.HttpContext.Session["ReportName"] = "rptAttendanceSummary.rpt";
                }
            }
        }
    }
}
