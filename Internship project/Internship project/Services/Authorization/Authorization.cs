using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Internship_project.Services.Authorization
{
    class Authorization : IAuthorization
    {
        public bool IsAutorization()
        {
            return UserData.User != null;
        }
        bool IAuthorization.Authorization(string Login, string Password)
        {
            var CurrentUser = Realm.GetInstance().All<User>().Where(u => u.Login == Login && u.Password == Password);

            if (CurrentUser.Any())
            {
                UserData.User = CurrentUser.First();

                return true;
            }

            return false;
        }
    }
}
