using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_project.Model.Tables
{
    class User: RealmObject
    {

        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
