using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ACSAdminWeb.Models
{
    public class LeaveModel
    {
        public DataTable leaveDT { get; set; }

        string strFromDate = System.Web.HttpContext.Current.Session["rptFromDate"].ToString();          // Setting FromDate
        string strToDate = System.Web.HttpContext.Current.Session["rptToDate"].ToString();              // Setting ToDate
        string strYear = System.Web.HttpContext.Current.Session["rptYear"].ToString();                  // Setting FromDate
        string strType = System.Web.HttpContext.Current.Session["rptSelectType"].ToString();            // Setting ToDate
        string strEmpID = System.Web.HttpContext.Current.Session["rptEmployeeId"].ToString();

        public LeaveModel()
        {
            string strQry = "";
            if (strType == "1")
            {
                strQry = "USP_LEAVESUMMARY_RPT " + strYear + ", '" + strEmpID + "'";
            }
            else
            {
                strQry = "SELECT r.eId,r.LeaveType,r.NoOfDay,d.leaveDate,p.Name FROM LeaveReason as r,LeaveDetails as d,personal as p WHERE (r.LeaveId=d.LeaveId) and (r.eId=p.pId) and (r.eId = " + strEmpID + ") and (d.leaveDate between '" + strFromDate + "' and '" + strToDate + "') ORDER BY r.eId,d.LeaveDate ASC";
            }

            string connString = "Database=Attendance;Server=SERVER2;persist security info=True;user id=rafique;password=bipul;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //string strQry = "";
                using (SqlCommand objCommand = new SqlCommand(strQry, conn))
                {
                    objCommand.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(objCommand);
                    conn.Open();
                    adp.Fill(dt);
                    this.leaveDT = dt;
                }
            }
        }
    }
}