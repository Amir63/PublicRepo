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
    
    public partial class SubjectArea
    {
        public SubjectArea()
        {
            this.Courses = new HashSet<Course>();
        }
    
        public short SubjectAreaID { get; set; }
        public string SubjectAreaName { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
    }
}
