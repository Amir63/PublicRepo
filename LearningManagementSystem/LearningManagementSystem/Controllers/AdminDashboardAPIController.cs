using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearningManagementSystem.Models;
using System.Configuration;
using LearningManagementSystem.Models.AdminModels;

namespace LearningManagementSystem.Controllers
{
    public class AdminDashboardAPIController : ApiController
    {
        public List<UnassignedUser> GetUnassignedUsers()
        {
            List<UnassignedUser> Users = new List<UnassignedUser>();

            using (SqlConnection cn = new SqlConnection(Settings.GetAdminDashboardConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetUnassignedUsers";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UnassignedUser user = new UnassignedUser();

                        user.LastName = dr["LastName"].ToString();
                        user.FirstName = dr["FirstName"].ToString();
                        user.Email = dr["Email"].ToString();
                        user.RequestedRoleName = dr["RequestedRoleName"].ToString();
                        user.Id = dr["Id"].ToString();
                        Users.Add(user);

                    }

                }

            }
            return Users;
        }


        public EditUserDetails GetUserToUpdate(string id)
        {
           
            using (SqlConnection cn = new SqlConnection(Settings.GetAdminDashboardConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "LoadUserDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);


                cmd.Connection = cn;
                cn.Open();
                EditUserDetails user = new EditUserDetails();
                user.Id = id;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {


                        user.LastName = dr["LastName"].ToString();
                        user.FirstName = dr["FirstName"].ToString();
                        if (dr["GradeLevelShort"] != DBNull.Value)
                        {
                            user.GradeLevel.GradeLevelShort = dr["GradeLevelShort"].ToString();
                            user.GradeLevel.GradeLevelId = (byte) dr["GradeLevelID"];
                        }


                    }

                }
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandText = "LoadUserRoles";
                cmd1.CommandType = CommandType.StoredProcedure;
                user.RequestedRoles = new List<Role>();
                cmd1.Parameters.AddWithValue("@id", id);
                cmd1.Connection = cn;
                using (SqlDataReader dr1 = cmd1.ExecuteReader())
                {

            
                        while (dr1.Read())
                        {
                            
                            user.RequestedRoles.Add(new Role(dr1["Name"].ToString(),dr1["id"].ToString() ));
                        }
                    

                }
                return user;
            }
           
        }

        public void PostUser(EditUserDetails user)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection cn = new SqlConnection(Settings.GetAdminDashboardConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UpdateUser";
                    cmd.Parameters.AddWithValue("@lastname", user.LastName);
                    cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                    cmd.Parameters.AddWithValue("@gradelevelid", user.GradeLevel);
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd.CommandText = "UpdateUserRoles";
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    if (user.RequestedRoles == null)
                    {
                        cmd.Parameters.AddWithValue("@isStudent", 0);
                        cmd.Parameters.AddWithValue("@isTeacher", 0);
                        cmd.Parameters.AddWithValue("@isParent", 0);
                        cmd.Parameters.AddWithValue("@isAdmin", 0);

                    }
                    else
                    {
                        if (user.RequestedRoles.Any(m => m.RoleID == "1"))
                        {
                            cmd.Parameters.AddWithValue("@isStudent", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@isStudent", 0);
                        }

                        if (user.RequestedRoles.Any(m => m.RoleID == "2"))
                        {
                            cmd.Parameters.AddWithValue("@isParent", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@isParent", 0);
                        }

                        if (user.RequestedRoles.Any(m => m.RoleID == "3"))
                        {
                            cmd.Parameters.AddWithValue("@isTeacher", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@isTeacher", 0);
                        }

                        if (user.RequestedRoles.Any(m => m.RoleID == "4"))
                        {
                            cmd.Parameters.AddWithValue("@isAdmin", 1);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@isAdmin", 0);
                        }
                    }
                    cmd1.ExecuteNonQuery();

                }
            }
        }

    }
}
