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
    public class HolidayList
    {
        //public int ID { set; get; }
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy, dddd}", ApplyFormatInEditMode = true)]
        public DateTime CalDate { set; get; }
        public string HolidayName { set; get; }
        public string ImplementedOn { set; get; }

        //public virtual UpdateGroupViewModel UpdateGroupViewModel { get; set; }
    }

    public class SearchHoliday
    {
        public IEnumerable<HolidayList> HolidayLists { get; set; }
        public SelectList SelectHolidayList { get; set; }
        public HolidayList HolidayList { get; set; }
        //public IEnumerable<UpdateGroupViewModel> UpdateGroupViewModels { get; set; }

        public List<DataRow> GetHoliday(string FromDate, string ToDate, string eGroup, string HolidayType)
        {
            List<DataRow> holidayList =null;
            string srtQry = "USP_HOLIDAY_LIST '" + FromDate + "', '" + ToDate + "', '" + eGroup + "', '" + HolidayType + "'";
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
                        holidayList = dt.AsEnumerable().ToList();
                    }
                }
            }
            return holidayList;
        }

        public SearchHoliday(string FromDate, string ToDate, string eGroup, string HolidayType)
        {
            var items = this.GetHoliday(FromDate, ToDate, eGroup, HolidayType);
            int i = 0;

            var holidayLists = (from p in items
                          select new HolidayList()
                          {
                              //ID = p.Field<int>("ID"),
                              CalDate = p.Field<DateTime>("CalDate"),
                              HolidayName = p.Field<string>("HolidayName"),
                              ImplementedOn = p.Field<string>("ImplementedOn")
                          }).ToList();

            //holidayLists = holidayLists
            //    //.OrderBy(p => p.EmployeeGroup)
            //    .ToList();

            this.HolidayLists = holidayLists;
            //this.GroupSelectList = new SelectList(Groups, "EmployeeGroup", "EmployeeGroup");
        }
    }
}