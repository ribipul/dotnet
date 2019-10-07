using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACSAdminWeb.Models
{
    public class ComboList
    {
        public int ItemID { set; get; }
        public string ItemName { set; get; }
    }

    public class GenerateComboList
    {
        public IEnumerable<ComboList> ComboLists { get; set; }
        public SelectList ComboListSelectList { get; set; }
        //public SelectListItem GroupSelectListItem { get; set; }
        public ComboList ComboList { get; set; }
        string srtQry = "";

        public List<DataRow> GetComboList(string strSQL)
        {
            List<DataRow> combolistss = null;

            srtQry = strSQL;
            //string srtQry = strSQL;  //"SELECT '0' As GroupId, 'General Holiday' As EmployeeGroup UNION ALL SELECT Id As GroupId, 'Group ''' + EmpGroup + ''' Holiday' As EmployeeGroup FROM FN_Alternate_Holiday_Group('Single') WHERE Id <> 1 UNION ALL SELECT Id As GroupId, 'Group ''' + EmpGroup + ''' Alternate Holiday' As EmployeeGroup FROM FN_Alternate_Holiday_Group('Single') WHERE Id <> 1";
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
                        combolistss = dt.AsEnumerable().ToList();
                    }
                }
            }
            return combolistss;
        }

        public GenerateComboList(string strSQL = "")
        {
            var items = this.GetComboList(strSQL);
            int i = 0;
            var combolistss = (from p in items
                               select new ComboList()
                          {
                              ItemID = p.Field<int>("ItemID"),
                              ItemName = p.Field<string>("ItemName")
                          });

            combolistss = combolistss
                //.OrderBy(p => p.EmployeeGroup)"
                .ToList();

            this.ComboLists = combolistss;
            this.ComboListSelectList = new SelectList(ComboLists, "ItemName", "ItemName");
            //this.GroupSelectListItem = new SelectListItem();
        }
    }
}