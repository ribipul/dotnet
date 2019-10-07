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
    public class SalaryAdvanceController : Controller
    {
        //
        // GET: /SalaryAdvance/
        GenerateComboList comboList = new GenerateComboList("SELECT P.PID As ItemID, P.Designation AS ItemName FROM Personal P, Department D WHERE D.EmpID = P.PID");
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                System.Web.HttpContext.Current.Session["LoginName"] = User.Identity.Name;
                LoadLeave loadLeave = new LoadLeave();

                var cmbList = comboList.ComboLists;
                ViewBag.ItemName = new SelectList(cmbList, "ItemName", "ItemName");

                return View(loadLeave.LeaveApplications);
            }
            else
            {
                return RedirectToAction("LogOn", "Account");
            }
        }

        [HttpPost]
        public void ShowGenericRptInNewWin(string EmployeeName, string Designation, string JoinDate, string Supervisor,
            string Salary, string HeadAF, string HeadHR, string Amount, string RecoveryAmount, string RecoveryPeriod, 
            string Disbursement, string RecoveryCommence, string RecoveryCompleted, string Purpose)
        {
            UserAuthentication userAuth = new UserAuthentication();

            this.HttpContext.Session["rptEmployeeId"] = userAuth.GetUserID(User.Identity.Name);

            this.HttpContext.Session["ReportName"] = "rptLoanApplication.rpt";
            string srtQry =
                "SELECT '" + EmployeeName + "' As EmployeeName, '" + Designation + "' As Designation, '" + JoinDate + "' As JoinDate, '" + Supervisor + "' As Supervisor, '" + Salary + "' As MonthlySalary, '" + HeadAF + "' As HeadAF, '" +
                HeadHR + "' As HeadHR, '" + Amount + "' As LoanAmount, '" + RecoveryAmount + "' RecoveryAmount, '" + RecoveryPeriod + "' As Duration, '" + Disbursement + "' As Disbursement, '" + RecoveryCommence + "' Commence, '" +
                RecoveryCompleted + "' As Completed, '" + Purpose + "' As Purpose";

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
