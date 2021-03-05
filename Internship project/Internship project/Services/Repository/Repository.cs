using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_project.Services.Repository
{
    class Repository<RealmObject> : IRepository<RealmObject>
    {

        public void Add(RealmObject item)
        {
            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            _transaction.Commit();

            _transaction.Dispose();

        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        RealmObject IRepository<RealmObject>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
