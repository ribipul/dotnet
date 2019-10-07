using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ACSAdminWeb.Models
{
    public class Group
    {
        public int GroupId { set; get; }
        public string EmployeeGroup { set; get; }
    }

    public class UpdateGroupViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public SelectList GroupSelectList { get; set; }
        //public SelectListItem GroupSelectListItem { get; set; }
        public Group Group { get; set; }

        public List<DataRow> GetGroup()
        {
            List<DataRow> groups = null;

            string srtQry = "SELECT '0' As GroupId, 'General Holiday' As EmployeeGroup UNION ALL SELECT Id As GroupId, 'Group ''' + EmpGroup + ''' All Holidays' As EmployeeGroup FROM FN_Alternate_Holiday_Group('Single') WHERE Id <> 1 UNION ALL SELECT Id As GroupId, 'Group ''' + EmpGroup + ''' Alternate Holidays' As EmployeeGroup FROM FN_Alternate_Holiday_Group('Single') WHERE Id <> 1";
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
                        groups = dt.AsEnumerable().ToList();
                    }
                }
            }
            return groups;
        }

        public UpdateGroupViewModel()
        {
            var items = this.GetGroup();
            int i = 0;
            
            var groups = (from p in items
                          select new Group()
                          {
                              GroupId = p.Field<int>("GroupId"),
                              EmployeeGroup =  p.Field<string>("EmployeeGroup")
                          });

            groups = groups
                //.OrderBy(p => p.EmployeeGroup)"
                .ToList();

            this.Groups = groups;
            this.GroupSelectList = new SelectList(Groups, "EmployeeGroup", "EmployeeGroup");
            //this.GroupSelectListItem = new SelectListItem();
        }
    }
}