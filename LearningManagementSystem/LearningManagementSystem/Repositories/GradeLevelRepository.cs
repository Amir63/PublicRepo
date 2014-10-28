using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace LearningManagementSystem.Repositories
{
    public class GradeLevelRepository
    {
        public List<SelectListItem> GetAllForRegistration()
        {
            List<SelectListItem> TheList = new List<SelectListItem>();
            TheList.Add(new SelectListItem() { Text = "N/A", Value = "200" });
            using (var context = new SelectFromDatabaseEntities())
            {
                var GradeLevels = context.GradeLevels.Where(m => m.GradeLevelID != null).OrderBy(m => m.SortOrder);
                foreach (var grade in GradeLevels)
                {
                    TheList.Add(new SelectListItem() { Text = grade.GradeLevelShort, Value = grade.GradeLevelID.ToString() });
                }
            }
            return TheList;
        }

    }
}