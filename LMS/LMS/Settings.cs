using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LMS
{
    public class Settings
    {

        public static string GetDefaultConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }
        public static string GetSelectLoginString
        {
            get { return ConfigurationManager.ConnectionStrings["SelectLoginConnection"].ConnectionString; }
        }

        public static string GetAdminDashboardConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["AdminDashboardConnectionString"].ConnectionString; }
        }
    }
}