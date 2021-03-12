using Internship_project.Model.Language;
using Internship_project.Model.Tables;
using Internship_project.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Internship_project.Model.UserData
{
    
    public static class UserData
    {
        public static User User { get; set; }
        public static ISettings settings;

        static UserData()
        {
            settings = new Settings
            {
                Language = new English()
            };
        }



    }
}
