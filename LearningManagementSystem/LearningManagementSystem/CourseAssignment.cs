//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LearningManagementSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseAssignment
    {
        public CourseAssignment()
        {
            this.CourseAssignmentRosters = new HashSet<CourseAssignmentRoster>();
        }
    
        public int CourseAssignmentID { get; set; }
        public int CourseID { get; set; }
        public string Name { get; set; }
        public short PossiblePoints { get; set; }
        public System.DateTime DueDate { get; set; }
        public string AssignmentDescription { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual ICollection<CourseAssignmentRoster> CourseAssignmentRosters { get; set; }
    }
}