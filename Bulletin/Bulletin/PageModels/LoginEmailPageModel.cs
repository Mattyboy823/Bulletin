using Bulletin.PageModels.Base;
using Bulletin.Services.Account;
using Bulletin.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bulletin.PageModels
{
    public class LoginEmailPageModel : PageModelBase
    {
        private ICommand signInCommand;
        private INavigationService _nagivationService;
        private IAccountService _accountService;

        public ICommand SignInCommand
        {
            get => signInCommand;
            set => SetProperty(ref signInCommand, value);
        }

        private string username;
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public LoginEmailPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _nagivationService = navigationService;
            _accountService = accountService;
            SignInCommand = new Command(OnSignInAction);
        }

        private async void OnSignInAction(object obj)
        {
            var loginAttempt = await _accountService.LoginAsync(Username, Password);
            if (loginAttempt)
            {
                await _nagivationService.NavigateToAsync<DashboardPageModel>();
            }
            else
            {
                //display failure alert
            }

        }
    }
}
