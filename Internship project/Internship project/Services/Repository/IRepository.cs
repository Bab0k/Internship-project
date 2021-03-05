using System;
using System.Collections.Generic;
using System.Text;
using Internship_project.Model.Tables;

namespace Internship_project.Services.Repository
{
    interface IRepository<RealmObject>
    {
        void Add(RealmObject item);
        void Delete();
        void Update();
        RealmObject GetAll();
    }
}
