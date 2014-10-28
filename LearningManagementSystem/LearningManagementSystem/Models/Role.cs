using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class Role
    {
        public string RoleName { get; set; }
        public string RoleID { get; set; }

        public Role(string name, string id)
        {
            RoleName = name;
            RoleID = id;
        }
    }
}