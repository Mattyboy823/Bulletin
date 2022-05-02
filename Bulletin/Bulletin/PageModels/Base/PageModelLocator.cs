using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;
using Bulletin.Services.Navigation;
using Bulletin.Pages;
using Bulletin.Services.Account;
using Bulletin.Services.Statement;
using Bulletin.Services.Work;

namespace Bulletin.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer container;
        static Dictionary<Type, Type> viewLookup;

        static PageModelLocator()
        {
            container = new TinyIoCContainer();
            viewLookup = new Dictionary<Type, Type>();

            //register pages and pagemodels
            Register<LoginPageModel, LoginPage>();
            Register<LoginEmailPageModel, LoginEmailPage>();
            Register<LoginPhonePageModel, LoginPhonePage>();
            Register<DashboardPageModel, DashboardPage>();
            Register<ProfilePageModel, ProfilePage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<SummaryPageModel, SummaryPage>();
            Register<TimeClockPageModel, TimeClockPage>();

            //register services (services are singletons be default)
            container.Register<INavigationService, NavigationService>();
            container.Register<IAccountService>(DependencyService.Get<IAccountService>());
            container.Register<IStatementService, MockStatementService>();
            container.Register<IWorkService, MockWorkService>();
        }

        public static T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            viewLookup.Add(typeof(TPageModel), typeof(TPage));
            container.Register<TPageModel>();
        }
    }
}
