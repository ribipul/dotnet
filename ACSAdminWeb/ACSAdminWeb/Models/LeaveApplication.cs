using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACSAdminWeb.Models
{
    public class LeaveApplication
    {
        public string EmployeeName { set; get; }
        public string Designation { set; get; }
        public string ContactNo { set; get; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime JoinDate { set; get; }
        public string Supervisor { set; get; }
        public string DepartmentName { set; get; }
        public string HeadHR { set; get; }
    }

    public class LoadLeave
    {
        string strLName = System.Web.HttpContext.Current.Session["LoginName"].ToString();

        public IEnumerable<LeaveApplication> LeaveApplications { get; set; }
        public SelectList LeaveSelectList { get; set; }
        public LeaveApplication LeaveApplication { get; set; }

        public List<DataRow> GetLeaveData()
        {
            List<DataRow> leaveapplications = null;

            string strQry = "";

            strQry = "SELECT E.Name, E.Designation, E.empContactNo, E.JoinDate, (SELECT P.Designation FROM Personal P, Department D WHERE D.EmpID = P.PID And D.ID = E.DeptID) As Supervisor, D2.DeptName, (SELECT P.Designation FROM Personal P, Department D WHERE D.EmpID = P.PID And D.ID = 6) As HeadHR FROM Personal E, Department D2, UserAuthentication U WHERE D2.ID = E.DeptID And E.empActive = 1 And E.pId = U.uId And U.uLoginName = '" + strLName + "'";
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
                    if (dt != null)
                    {
                        leaveapplications = dt.AsEnumerable().ToList();
                    }
                }
            }
            return leaveapplications;
        }

        public LoadLeave()
        {
            var items = this.GetLeaveData();

            var leaveapplications = (from p in items
                                     select new LeaveApplication()
                                     {
                                         EmployeeName = p.Field<string>("Name"),
                                         Designation = p.Field<string>("Designation"),
                                         ContactNo = p.Field<string>("empContactNo"),
                                         JoinDate = p.Field<DateTime>("JoinDate"),
                                         Supervisor = p.Field<string>("Supervisor"),
                                         DepartmentName = p.Field<string>("DeptName"),
                                         HeadHR = p.Field<string>("HeadHR")
                                     });

            leaveapplications = leaveapplications.ToList();

            this.LeaveApplications = leaveapplications;
            //this.LeaveSelectList = new SelectList(LeaveApplications, "EmployeeGroup", "EmployeeGroup");
        }
    }
}