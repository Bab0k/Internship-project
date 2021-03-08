using Realms;
using System;
using Xamarin.Forms;

namespace Internship_project.Model.Tables
{
    public class Profile: RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdUser { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}
