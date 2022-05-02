using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using System.Threading.Tasks;
using System.Timers;
using Bulletin.Models;
using Bulletin.PageModels.Base;
using Bulletin.Services.Account;
using Bulletin.Services.Work;
using Bulletin.ViewModels.Buttons;

namespace Bulletin.PageModels
{
    public class TimeClockPageModel : PageModelBase
    {
        bool isClockedIn;
        public bool IsClockedIn
        {
            get => isClockedIn;
            set => SetProperty(ref isClockedIn, value);
        }
        TimeSpan runningTotal;
        public TimeSpan RunningTotal
        {
            get => runningTotal;
            set => SetProperty(ref runningTotal, value);
        }

        DateTime currentStartTime;
        public DateTime CurrentStartTime
        {
            get => currentStartTime;
            set => SetProperty(ref currentStartTime, value);
        }
        ObservableCollection<WorkItem> workItems;
        public ObservableCollection<WorkItem> WorkItems
        {
            get => workItems;
            set => SetProperty(ref workItems, value);   
        }

        double todaysEarnings;
        public double TodaysEarnings
        {
            get => todaysEarnings; 
            set => SetProperty(ref todaysEarnings, value);
        }
        ButtonModel clockInOutButtonModel;

        public ButtonModel ClockInOutButtonModel
        {
            get => clockInOutButtonModel;
            set => SetProperty(ref clockInOutButtonModel, value); 
        }

        private Timer timer;
        private IAccountService _accountService;
        private IWorkService workService1;
        private double hourlyRate;
        public TimeClockPageModel(IAccountService accountService, IWorkService workService)
        {
            _accountService = accountService;
            workService1 = workService;
            clockInOutButtonModel = new ButtonModel("Clock In", OnClockInOutAction);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = false;
            timer.Elapsed += timerElapsed;
        }

        private void timerElapsed(object sender, ElapsedEventArgs e)
        {
            RunningTotal += TimeSpan.FromSeconds(1);
        }

        public override async Task InitializeAsync(object navigationData)
        {
            RunningTotal = new TimeSpan();
            hourlyRate = await _accountService.GetCurrentPayRateAsync();
            WorkItems = await workService1.GetTodaysWorkAsync();
            await base.InitializeAsync(navigationData);
        }

        private async void OnClockInOutAction()
        {
            if (IsClockedIn)
            {
                timer.Enabled = false;
                TodaysEarnings += hourlyRate * RunningTotal.TotalHours;
                RunningTotal = TimeSpan.Zero;
                ClockInOutButtonModel.Text = "Clock In";
                var item = new WorkItem
                {
                    Start = CurrentStartTime,
                    End = DateTime.Now
                };
                WorkItems.Insert(0, item);
                await workService1.LogWorkAsync(item);
            }
            else
            {
                CurrentStartTime = DateTime.Now;
                timer.Enabled = true;
                ClockInOutButtonModel.Text = "Clock Out";
            }
            IsClockedIn = !IsClockedIn;
        }
    }
}
