using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LMS.Models;

namespace LMS.Repositories
{
    public class UserInfoRepository
    {

        public void InsertIntoUserInfo( RegisterViewModel model, string id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.GetDefaultConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "InsertIntoUserInfo";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                if(model.GradeLevelID != null)
                    cmd.Parameters.AddWithValue("@GradeLevel", model.GradeLevelID);
                cmd.Parameters.AddWithValue("@RequestedRole", model.RequestedRoleID);
                cmd.Connection = cn;
             
                cn.Open();
                cmd.ExecuteNonQuery();
                
            }
        }
    }
}