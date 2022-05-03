using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bulletin.Database
{
    public class Workday
    {
        [PrimaryKey, AutoIncrement]
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double TotalHours { get; set; }
    }
}
