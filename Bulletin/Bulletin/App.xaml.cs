using Bulletin.Services.Navigation;
using Bulletin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using Bulletin.PageModels.Base;
using Bulletin.PageModels;

namespace Bulletin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve < INavigationService>();
            return navService.NavigateToAsync<LoginPageModel>();
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
