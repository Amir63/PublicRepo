using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Repositories
{
    public class UserInfoRepository
    {

        public void Insert(RegisterViewModel model ,string id)
        {
            
            using (var context = new UserInfoInsertEntities())
            {
                context.InsertIntoUserInfo(id, model.FirstName, model.LastName, model.Email,  model.GradeLevelID,
                   model.RequestedRoleID);
            }

            
        }
    }
}