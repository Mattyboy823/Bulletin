using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Bulletin.Database
{
    public class EmployeeDb
    {
        readonly SQLiteAsyncConnection db;

        public EmployeeDb(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Person>().Wait();
        }

        public Task<List<Person>> GetPeopleAsync()
        {
            return db.Table<Person>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Person person)
        {
            return db.InsertAsync(person);
        }
        public Task<int> UpdatePersonAsync (Person person)
        {
            return db.UpdateAsync(person);
        }
        public Task<int> DeletePersonAsync(Person person)
        {
            return db.DeleteAsync(person);
        }
        public Task<List<Person>> IsInAsync()
        {
            return db.QueryAsync<Person>("SELECT * FROM Person WHERE IsIn=true");
        }
        public Task<List<Person>> NotInAsync()
        {
            return db.Table<Person>().Where(p => p.IsIn == false).ToListAsync();
        }

    }
}
