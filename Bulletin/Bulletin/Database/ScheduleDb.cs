using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bulletin.Database
{
    public class ScheduleDb
    {
        readonly SQLiteAsyncConnection db;
        
        public ScheduleDb(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Workday>().Wait();
        }
    }
}
