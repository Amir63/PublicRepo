using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models.AdminModels
{
    public class EditUserDetails
    {
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }

        public GradeLevelModel GradeLevel { get; set; }


        public string Id { get; set; }


        public List<Role> RequestedRoles { get; set; }
        public string[] SelectedRoles { get; set; }
    }
}