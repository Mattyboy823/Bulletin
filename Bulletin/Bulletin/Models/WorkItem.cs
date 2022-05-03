using Bulletin.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bulletin.Models
{
    public class WorkItem : IIdentifiable
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Total 
        { 
            get => End - Start;
        }

        public string Id {get; set; }
    }
}
