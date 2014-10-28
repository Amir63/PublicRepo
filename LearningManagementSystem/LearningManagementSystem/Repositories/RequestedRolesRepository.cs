using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace LearningManagementSystem.Repositories
{
    public class RequestedRolesRepository
    {
        public List<SelectListItem> GetAllForRegistration()
        {
            List<SelectListItem> TheList = new List<SelectListItem>();
           
            using (var context = new SelectFromDatabaseEntities())
            {
                var Roles = context.RequestedRoles.Where(m => m.RequestedRoleID != null);
                foreach (var role in Roles)
                {
                    TheList.Add(new SelectListItem(){Text = role.RequestedRoleName, Value = role.RequestedRoleID.ToString()});
                }
            }
            return TheList;
        }

       
    }


}