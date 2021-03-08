using Internship_project.Model.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Internship_project.Model.UserData
{
    
    public static class UserData
    {
        public static User User { get; set; }
        public static IQueryable<Profile> Profiles;
    }
}
