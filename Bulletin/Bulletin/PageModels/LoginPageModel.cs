using System;
using System.Collections.Generic;
using System.Text;
using Bulletin.PageModels.Base;
using System.Windows.Input;
using Xamarin.Forms;
using Bulletin.Services.Navigation;
using Bulletin.Services.Account;
using Bulletin.ViewModels;

namespace Bulletin.PageModels
{
    
    public class LoginPageModel : PageModelBase
    {
        private string icon;
        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }
        private LoginOptionViewModel loginPhoneViewModel;
        public LoginOptionViewModel LoginPhoneViewModel
        {
            get => loginPhoneViewModel;
            set => SetProperty(ref loginPhoneViewModel, value);
        }
        private LoginOptionViewModel loginEmailViewModel;
        public LoginOptionViewModel LoginEmailViewModel
        {
            get => loginEmailViewModel;
            set => SetProperty(ref loginEmailViewModel, value);
        }

        private INavigationService navigationService1;

        public LoginPageModel(INavigationService navigationService)
        {
            navigationService1 = navigationService;
            LoginPhoneViewModel = new LoginOptionViewModel("Sign in with phone", GoToPhoneLogin, Color.FromHex("#02bd7e"));
            LoginEmailViewModel = new LoginOptionViewModel("Sign in with email", GoToEmailLogin, Color.FromHex("#db4437"));
        }

        private void GoToEmailLogin()
        {
            navigationService1.NavigateToAsync<LoginEmailPageModel>();
        }

        private void GoToPhoneLogin()
        {
            navigationService1.NavigateToAsync<LoginPhonePageModel>();
        }
    }
}
