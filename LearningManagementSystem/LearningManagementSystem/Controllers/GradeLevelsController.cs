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
    public class GradeLevelsController : ApiController
    {

        public List<GradeLevelModel> GetGradeLevels()
        {
            List<GradeLevelModel> grades = new List<GradeLevelModel>();
            using (SqlConnection cn = new SqlConnection(Settings.GetSelectLoginString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "select GradeLevelID, GradeLevelShort from gradelevel";
                cmd.Connection = cn;

                cn.Open();
                grades.Add(new GradeLevelModel("N/A", 200));
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                      
                        grades.Add(new GradeLevelModel(dr["GradeLevelShort"].ToString(), (byte) dr["GradeLevelID"]));

                    }
                }
                return grades;
            }
        }
    }
}
