using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACSAdminWeb.Models
{
    public class UserModel
    {
        public int uId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string uLoginName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string uPasswd { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeGroup { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class UserAuthentication
    {
        public IEnumerable<UserModel> UserModels { get; set; }
        public SelectList GroupSelectList { get; set; }
        public UserModel UserModel { get; set; }

        public List<DataRow> GetUser()
        {
            List<DataRow> users = null;

            string srtQry = "SELECT u.uId, u.uloginName, u.uPasswd, p.Name, p.empGroup FROM UserAuthentication u INNER JOIN Personal p ON u.uId = p.pId"; // "SELECT * FROM UserAuthentication";
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
                        users = dt.AsEnumerable().ToList();
                    }
                }
            }
            return users;
        }

        public UserAuthentication()
        {
            var items = this.GetUser();

            var groups = (from p in items
                          select new UserModel()
                          {
                              uId = p.Field<int>("uId"),
                              uLoginName = p.Field<String>("uLoginName"),
                              uPasswd = p.Field<String>("uPasswd"),
                              EmployeeName = p.Field<String>("Name"),
                              EmployeeGroup = p.Field<String>("empGroup")
                          });

            groups = groups
                .OrderBy(p => p.uLoginName)
                .ToList();

            this.UserModels = groups;
            //this.GroupSelectList = new SelectList(UserModels);
        }

        public string GetUserID(string userLogIn)
        {
            var user = from o in this.UserModels where o.uLoginName == userLogIn select o;
            if (user.ToList().Count > 0)
                return user.First().uId.ToString();
            else
                return string.Empty;
        }
        
        public string GetEmployeeName(string userLogIn)
        {
            var user = from o in this.UserModels where o.uLoginName == userLogIn select o;
            if (user.ToList().Count > 0)
                return user.First().EmployeeName;
            else
                return string.Empty;
        }

        public string GetEmployeeGroup(string userLogIn)
        {
            var user = from o in this.UserModels where o.uLoginName == userLogIn select o;
            if (user.ToList().Count > 0)
                return user.First().EmployeeGroup;
            else
                return string.Empty;
        }

        public virtual bool ChangePassword(string userID, string oldPassword, string newPassword)
        {
            ACSSecurityServices.CheckPasswordParameter(oldPassword, "oldPassword");
            ACSSecurityServices.CheckPasswordParameter(newPassword, "newPassword");
            if (this.UpdateSelf(userID, newPassword))
                return true;

            return false;
        }

        public bool UpdateSelf(string userID, string newPassword)
        {
            bool update;
            try
            {
                string connectionString = "Database=Attendance;Server=SERVER2;persist security info=True;user id=rafique;password=bipul;";

                using (SqlConnection conn =new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE UserAuthentication SET uPasswd=@Passwd" + " WHERE uId=@ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", userID);
                        cmd.Parameters.AddWithValue("@Passwd", newPassword);

                        int rows = cmd.ExecuteNonQuery();
                        update = true;
                        //rows number of record got updated
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log exception
                //Display Error message
                update = false;
            }
            return update;
        }
    }
}