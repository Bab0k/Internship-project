using Internship_project.Model.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Internship_project.Services.Repository
{
    class ProfileRepository
    {
        private SQLiteConnection database;

        public ProfileRepository()
        {
            database = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProfileBook.db"));
            database.CreateTable<Profile>();
        }
        public IEnumerable<Profile> GetItems()
        {
            return database.Table<Profile>().ToList();
        }
        public Profile GetItem(int id)
        {
            return database.Get<Profile>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Profile>(id);
        }

        /*
        public int SaveItem(Profile item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public Profile GetByName(string Login)
        {
            return database.Find<Profile>(u => u.Login == Login);
        }
        */
    }
}
