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
    public class CompensatoryLeaveController : Controller
    {
        //
        // GET: /CompensatoryLeave/

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
        public void ShowGenericRptInNewWin(string EmployeeName, string ContactNo, string SubDate, string Supervisor, 
            string EFrom1, string EFrom2, string EFrom3, string EFrom4, string ETo1, string ETo2, string ETo3, string ETo4, string EDay1, string EDay2, string EDay3, string EDay4,
            string AFrom1, string AFrom2, string AFrom3, string AFrom4, string ATo1, string ATo2, string ATo3, string ATo4, string ADay1, string ADay2, string ADay3, string ADay4,
            string Training, string ITFair, string AttendingClient, string AttendingOffice, string Others,
            string HeadHR, string Designation, string DepartmentName, string AttnType)
        {
            UserAuthentication userAuth = new UserAuthentication();

            this.HttpContext.Session["rptEmployeeId"] = userAuth.GetUserID(User.Identity.Name);

            this.HttpContext.Session["ReportName"] = "rptCompensatoryLeave.rpt";
            string srtQry =
                "SELECT '" + SubDate + "' As SubmissionDate, '" + EmployeeName + "' As EmployeeName, '" + ContactNo + "' As ContactNo, '" + Designation + "' As EmpDesignation, '" + DepartmentName + "' As EmpDepartment, '" + Supervisor + "' As DeptHead, '" +
                EFrom1 + "' As EarnedDateF, '" + ETo1 + "' As EarnedDateT, '" + EDay1 + "' DayEarned, '" + EFrom2 + "' As EarnedDateF2, '" + ETo2 + "' As EarnedDateT2, '" + EDay2 + "' DayEarned2, '" +
                EFrom3 + "' As EarnedDateF3, '" + ETo3 + "' As EarnedDateT3, '" + EDay3 + "' DayEarned3, '" + EFrom4 + "' As EarnedDateF4, '" + ETo4 + "' As EarnedDateT4, '" + EDay4 + "' DayEarned4, '" +
                Training + "' As Training, '" + ITFair + "' As ITFair, '" + AttendingClient + "' AttendingClient, '" + AttendingOffice + "' As AttendingOffice, '" + Others + "' As Others, '" +
                AFrom1 + "' As AvailedDateF, '" + ATo1 + "' As AvailedDateT, '" + ADay1 + "' DayAvailed, '" + AFrom2 + "' As AvailedDateF2, '" + ATo2 + "' As AvailedDateT2, '" + ADay2 + "' DayAvailed2, '" +
                AFrom3 + "' As AvailedDateF3, '" + ATo3 + "' As AvailedDateT3, '" + ADay3 + "' DayAvailed3, '" + AFrom4 + "' As AvailedDateF4, '" + ATo4 + "' As AvailedDateT4, '" + ADay4 + "' DayAvailed4, '" + HeadHR + "' As HeadHR";

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
