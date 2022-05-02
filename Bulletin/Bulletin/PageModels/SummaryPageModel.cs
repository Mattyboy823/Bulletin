using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulletin.Models;
using Bulletin.PageModels.Base;
using Bulletin.Services.Account;
using Bulletin.Services.Statement;
using Bulletin.Services.Work;
using Bulletin.ViewModels;

namespace Bulletin.PageModels
{
    public class SummaryPageModel : PageModelBase
    {
        private string currentPayDateRange;
        public string CurrentPayDateRange {
            get => currentPayDateRange;
            set => SetProperty(ref currentPayDateRange, value);
        }
        private double currentPeriodEarnings;
        public double CurrentPeriodEarnings {
            get => currentPeriodEarnings;
            set => SetProperty(ref currentPeriodEarnings, value);
        }
        private DateTime currentPeriodPayDate;
        public DateTime CurrentPeriodPayDate {
            get => currentPeriodPayDate;
            set => SetProperty(ref currentPeriodPayDate, value);
        }
        private List<PayStatementViewModel> statements1;
        public List<PayStatementViewModel> Statements {
            get => statements1;
            set => SetProperty(ref statements1, value);
        }
        private IAccountService accountService1;
        private IStatementService statementService1;
        private IWorkService workService1;
        private double hourlyRate;

        public SummaryPageModel(IStatementService statementService, IWorkService workService, IAccountService accountService)
        {
            accountService1 = accountService;
            statementService1 = statementService;
            workService1 = workService;
        }
        public override async Task InitializeAsync(object navigationData)
        {
            hourlyRate = await accountService1.GetCurrentPayRateAsync();
            var statements = await statementService1.GetStatementHistoryAsync();
            if (statements != null)
            {
                Statements = statements.Select(s => new PayStatementViewModel(s)).ToList();
                var lastStatement = statements.FirstOrDefault();
                if (lastStatement != null) 
                {
                    var today = DateTime.Now;
                    var max = 100;
                    var currentCount = 0;
                    var currentEnd = lastStatement.End;
                    while (currentEnd < today && currentCount < max)
                    {
                        currentEnd = currentEnd.AddDays(14);
                        ++currentCount;
                    }
                    if (currentEnd > today)
                    {
                        if (currentEnd.AddDays(-13) < today)
                        {
                            SetDateRange(currentEnd.AddDays(-13), currentEnd);
                        }
                    }
                }
            }
            var currentPeriodItems = await workService1.GetWorkForThisPeriodAsync();
            foreach(var item in currentPeriodItems)
            {
                CurrentPeriodEarnings += item.Total.TotalHours * hourlyRate;
            }
            await base.InitializeAsync(navigationData);
        }
        private void SetDateRange(DateTime start, DateTime end)
        {
            CurrentPayDateRange = start.ToString("MMMM d") + " - " + end.ToString("MMMM d, yyyy");
            CurrentPeriodPayDate = end.AddDays(6);
        }
    }
}
