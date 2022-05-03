using Bulletin.Services.Navigation;
using Bulletin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Bulletin.PageModels.Base;
using Bulletin.PageModels;
using Bulletin.Database;
using System.IO;

namespace Bulletin
{
    public partial class App : Application
    {
        private static EmployeeDb db;
        public static EmployeeDb Db
        {
            get
            {
                if (db == null)
                {
                    db = new EmployeeDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return db;
            }
        }
        private static ScheduleDb scheduleDb;
        public static ScheduleDb ScheduleDb
        {
            get
            {
                if (scheduleDb == null)
                {
                    scheduleDb = new ScheduleDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return scheduleDb;
            }
        }

        public App()
        {
            InitializeComponent();
        }
        

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve < INavigationService>();
            return navService.NavigateToAsync<LoginEmailPageModel>();
        }

        protected override async void OnStart()
        {
            await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
