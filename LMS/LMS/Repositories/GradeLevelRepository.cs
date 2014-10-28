using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMS.Models;

namespace LMS.Repositories
{
    public class GradeLevelRepository
    {
        public static  List<SelectListItem> GetAllForRegistration()
        {
            List<SelectListItem> grades = new List<SelectListItem>();
            grades.Add(new SelectListItem() { Text = "N/A", Value = "200" });
            using (SqlConnection cn = new SqlConnection(Settings.GetSelectLoginString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select GradeLevelID, GradeLevelShort from gradelevel";
                cmd.Connection = cn;

                cn.Open();
                SelectListItem theGrade = new SelectListItem();
                theGrade.Text = "N/A";
                theGrade.Value = "200";
                grades.Add(theGrade);

                
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        theGrade = new SelectListItem();
                        theGrade.Text = dr["GradeLevelShort"].ToString();
                        theGrade.Value = dr["GradeLevelID"].ToString();
                        grades.Add(theGrade);

                    }
                }
                return grades;
            }
        }
    }
}