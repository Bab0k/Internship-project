using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_project.Model.Tables
{

    class Profile: RealmObject
    {

        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdUser { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
        public byte[] File { get; set; }
        public string Date { get; set; }
    }

}
