using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LMS.Repositories
{
    public class RequestedRolesRepository
    {
        public static List<SelectListItem> GetAllForRegistration()
        {
            List<SelectListItem> roles = new List<SelectListItem>();
            using (SqlConnection cn = new SqlConnection(Settings.GetSelectLoginString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select RequestedRoleID, RequestedRoleName from RequestedRoles";
                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SelectListItem theGrade = new SelectListItem();
                        theGrade.Text = dr["RequestedRoleName"].ToString();
                        theGrade.Value = dr["RequestedRoleID"].ToString();
                        roles.Add(theGrade);
                    }
                }
                return roles;
            }
        }
    }
}