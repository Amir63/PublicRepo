using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningManagementSystem.Models
{
    public class GradeLevelModel
    {
        public string GradeLevelShort { get; set; }
        public byte GradeLevelId { get; set; }

        public GradeLevelModel(string Short, byte id)
        {
            GradeLevelShort = Short;
            GradeLevelId = id;
        }

 
    }
}