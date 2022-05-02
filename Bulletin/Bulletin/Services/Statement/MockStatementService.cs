﻿using Bulletin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulletin.Services.Statement
{
    public class MockStatementService :IStatementService
    {

        public List<PayStatement> items;
        public MockStatementService()
        {
            items = new List<PayStatement>()
           {
               new PayStatement
               {
                   Amount = 10,
                   Date = DateTime.Parse("06/12/2020"),
                   Start = DateTime.Parse("05/24/2020"),
                   End = DateTime.Parse("06/06/2020"),
                   WorkItems = new List<WorkItem>
                   {
                       new WorkItem
                       {
                           Start = DateTime.Parse("06/06/2020 12:00:00"),
                           End = DateTime.Parse("06/06/2020 13:00:00")
                       }
                   }

               }
           };
        }

        public Task<List<PayStatement>> GetStatementHistoryAsync()
        {
            return Task.FromResult(items.OrderByDescending(s => s.Start).ToList());
        }
    }
}