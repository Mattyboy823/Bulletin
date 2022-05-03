using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Bulletin.Database
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int HrsWorked { get; set; }
        public bool IsIn { get; set; }
    }
}
