using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACSAdminWeb.Models;

namespace ACSAdminWeb.Controllers
{
    public class GeneralLeaveController : Controller
    {
        //
        // GET: /GeneralLeave/

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                System.Web.HttpContext.Current.Session["LoginName"] = User.Identity.Name;
                LoadLeave loadLeave = new LoadLeave();

                return View(loadLeave.LeaveApplications);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        [HttpPost]
        public void ShowGenericRptInNewWin(string EmployeeName, string ContactNo, string SubDate, string Supervisor, string FromDate, string ToDate, string Days, string ResumptionDate, string Nature, string Purpose, string Designation, string DepartmentName, string AttnType)
        {
            UserAuthentication userAuth = new UserAuthentication();

            this.HttpContext.Session["rptEmployeeId"] = userAuth.GetUserID(User.Identity.Name);
           
            this.HttpContext.Session["ReportName"] = "rptLeaveApplication.rpt";
            string srtQry =
                "SELECT '" + EmployeeName + "' As EmployeeName, '" + ContactNo + "' As ContactNo, '" + Designation + "' As Designation, '" + DepartmentName + "' As Department, '" + SubDate + "' As Submission, '" + FromDate + "' As FromDate, '" + ToDate + "' As ToDate, '" + Days + "' As Duration, '" + ResumptionDate + "' As JoinDate, '" + Nature + "' As LeaveNature, '" + Purpose + "' As Purpose, '" + Supervisor + "' As Supervisor";

            string connString = "Database=Attendance;Server=SERVER2;persist security info=True;user id=rafique;password=bipul;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //string strQry = "";
                using (SqlCommand objCommand = new SqlCommand(srtQry, conn))
                {
                    objCommand.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(objCommand);
                    conn.Open();
                    adp.Fill(dt);
                    this.HttpContext.Session["rptSource"] = dt;
                }
            }
        }
    }
}
