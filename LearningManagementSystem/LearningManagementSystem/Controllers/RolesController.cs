using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Controllers
{
    public class RolesController : ApiController
    {
        public List<Role> GetRoles()
        {
             List<Role> roles = new List<Role>();
            using (SqlConnection cn = new SqlConnection(Settings.GetSelectLoginString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select * from aspnetroles order by id";
                cmd.Connection = cn;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {


                        roles.Add(new Role(dr["Name"].ToString(), dr["ID"].ToString()));

                    }
                }
                return roles;
            }
        }
    }
}
