using Bulletin.Models;
using Bulletin.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bulletin.ViewModels
{
    public class PayStatementViewModel : ExtendedBindableObject
    {
        private double earnings;
        public double Earnings
        {
            get => earnings;
            set => SetProperty(ref earnings, value);
        }
        private double totalHours;
        public double TotalHours
        {
            get => totalHours;
            set => SetProperty(ref totalHours, value);
        }
        private string payRange;
        public string PayRange
        {
            get => payRange;
            set => SetProperty(ref payRange, value);
        }

        public PayStatementViewModel(PayStatement statement)
        {
            PayRange = statement.Start.ToString("MMMM d") + " - " + statement.End.ToString("MMMM d, yyyy");
            Earnings = statement.Amount;
            foreach (var item in statement.WorkItems)
            {
                TotalHours += item.Total.TotalHours;
            }
        }
    }
}
