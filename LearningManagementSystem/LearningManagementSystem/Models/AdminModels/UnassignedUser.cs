using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.AdminModels
{
    public class UnassignedUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string RequestedRoleName { get; set; }
        public string Id { get; set; }
    }
}