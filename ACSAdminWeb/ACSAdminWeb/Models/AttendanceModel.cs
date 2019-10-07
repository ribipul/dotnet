using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ACSAdminWeb.Models
{
    public class AttendanceModel
    {
        public string CardNo { get; set; }
        public string Name { get; set; }
        public DateTime EDate { get; set; }
        public TimeSpan ETime { get; set; }
        public string EntryTime { get; set; }
    }

    public class AttendanceInOutDetails
    {
        public List<AttendanceModel> AttendanceInOutRpTs { get; set; }
        public AttendanceModel AttendanceInOutDetailsRpT { get; set; }

        string strFromDate = System.Web.HttpContext.Current.Session["rptFromDate"].ToString();     // Setting FromDate 
        string strToDate = System.Web.HttpContext.Current.Session["rptToDate"].ToString();         // Setting ToDate
        string strEmpID = System.Web.HttpContext.Current.Session["rptEmployeeId"].ToString();

        public List<DataRow> GetAttendanceDetails()
        {
            List<DataRow> getAttendanceDetails = null;

            string srtQry = "USP_ATTENDANCE_INOUT_DETAIL_RPT '" + strEmpID + "', '" + strFromDate + "', '" + strToDate + "'";
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
                    if (dt != null)
                    {
                        getAttendanceDetails = dt.AsEnumerable().ToList();
                    }
                }
            }
            return getAttendanceDetails;
        }

        public AttendanceInOutDetails()
        {
            var items = this.GetAttendanceDetails();

            var attenInOutRpts = (from p in items
                                  select new AttendanceModel()
                                  {
                                      CardNo = p.Field<string>("CardNo"),
                                      Name = p.Field<string>("Name"),
                                      EDate = p.Field<DateTime>("EDate"),
                                      ETime = p.Field<TimeSpan>("ETime"),
                                      EntryTime = p.Field<string>("EntryTime")
                                  }).ToList();

            this.AttendanceInOutRpTs = attenInOutRpts;
        }
    }
}