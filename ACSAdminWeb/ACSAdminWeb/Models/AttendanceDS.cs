using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ACSAdminWeb.Models
{
    public class AttendanceDS
    {
        public DateTime AttendanceDate { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeGroup { get; set; }
        public TimeSpan InTime { get; set; }
        public string Late { get; set; }
        public TimeSpan OutTime { get; set; }
        public string TotalWork { get; set; }
        public string AtOffice { get; set; }
        public string OfficeStartHour { get; set; }
        public int WorkingHour { get; set; }
        public float OutOfficeVisit { get; set; }
        public string Comments { get; set; }
        public string Purpose { get; set; }
        public string OverTime { get; set; }
        public string OutOffice { get; set; }
        public int TotalWorkingDay { get; set; }
        public int IndividualWorkingDay { get; set; }
    }

    public class AttendanceDetails
    {
        public List<AttendanceDS> AttendanceDSRpTs { get; set; }
        public AttendanceDS AttendanceDSRpT { get; set; }
        public DataTable attnDT { get; set; }

        string strFromDate = System.Web.HttpContext.Current.Session["rptFromDate"].ToString();     // Setting FromDate 
        string strToDate = System.Web.HttpContext.Current.Session["rptToDate"].ToString();         // Setting ToDate  
        string strEmpID = HttpContext.Current.Session["rptEmployeeId"].ToString();

        public List<DataRow> GetAttendance()
        {
            List<DataRow> getAttendance = null;

            string srtQry = "SET ARITHABORT ON" + System.Environment.NewLine +
                "SELECT AttendanceDate, EmployeeName, EmployeeGroup, InTime, Late, OutTime, TotalWork, AtOffice, OfficeStartHour, WorkingHour, OutOfficeVisit, Comments, Purpose, OverTime, OutOffice, TotalWorkingDay, IndividualWorkingDay " + System.Environment.NewLine +
                "FROM FN_AttendanceCTE_RPT('" + strFromDate + "', '" + strToDate + "', '," + strEmpID + ",')" + System.Environment.NewLine +
                "ORDER BY EmployeeName, AttendanceDate" + System.Environment.NewLine +
                "SET ARITHABORT OFF";
            string connString = "Database=Attendance;Server=SERVER2;persist security info=True;user id=rafique;password=bipul;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //string strQry = "";
                using (SqlCommand objCommand = new SqlCommand(srtQry, conn))
                {
                    objCommand.CommandType = CommandType.Text;
                    objCommand.CommandTimeout = 120;        // set timeout to something more then 30 
                    DataTable dt = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter(objCommand);
                    conn.Open();
                    adp.Fill(dt);
                    if (dt != null)
                    {
                        getAttendance = dt.AsEnumerable().ToList();
                    }
                }
            }
            return getAttendance;
        }

        public AttendanceDetails()
        {
            //var items = this.GetAttendance();

            //var attenDSRpts = (from p in items
            //                   select new AttendanceDS()
            //                      {
            //                          AttendanceDate = p.Field<DateTime>("AttendanceDate"),
            //                          EmployeeName = p.Field<string>("EmployeeName"),
            //                          EmployeeGroup = p.Field<string>("EmployeeGroup"),
            //                          InTime = p.Field<TimeSpan>("InTime"),
            //                          Late = p.Field<string>("Late"),
            //                          OutTime = p.Field<TimeSpan>("OutTime"),
            //                          TotalWork = p.Field<string>("TotalWork"),
            //                          AtOffice = p.Field<string>("AtOffice"),
            //                          OfficeStartHour = p.Field<string>("OfficeStartHour"),
            //                          WorkingHour = p.Field<int>("WorkingHour"),
            //                          OutOfficeVisit = p.Field<float>("OutOfficeVisit"),
            //                          Comments = p.Field<string>("Comments"),
            //                          Purpose = p.Field<string>("Purpose"),
            //                          OverTime = p.Field<string>("OverTime"),
            //                          OutOffice = p.Field<string>("OutOffice"),
            //                          TotalWorkingDay = p.Field<int>("TotalWorkingDay"),
            //                          IndividualWorkingDay = p.Field<int>("IndividualWorkingDay"),
            //                      }).ToList();

            //this.AttendanceDSRpTs = attenDSRpts;

            string srtQry = "SET ARITHABORT ON" + System.Environment.NewLine +
                "SELECT AttendanceDate, EmployeeName, EmployeeGroup, InTime, Late, OutTime, TotalWork, AtOffice, OfficeStartHour, WorkingHour, OutOfficeVisit, Comments, Purpose, OverTime, OutOffice, TotalWorkingDay, IndividualWorkingDay " + System.Environment.NewLine +
                "FROM FN_AttendanceCTE_RPT('" + strFromDate + "', '" + strToDate + "', '," + strEmpID + ",')" + System.Environment.NewLine +
                "ORDER BY EmployeeName, AttendanceDate" + System.Environment.NewLine +
                "SET ARITHABORT OFF";

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
                    this.attnDT = dt;
                }
            }
        }
    }
}