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
    public class LoginPhonePageModel : PageModelBase
    {
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }
        private string code;
        public string Code
        {
            get => code;
            set => SetProperty(ref code, value);
        }
        private bool codeSent;
        public bool CodeSent
        {
            get => codeSent;
            set => SetProperty(ref codeSent, value);
        }
        private string buttonText = "Send Code";
        public string ButtonText
        {
            get => buttonText;
            set => SetProperty(ref buttonText, value);
        }
        private ICommand nextCommand;
        public ICommand NextCommand
        {
            get => nextCommand;
            set => SetProperty(ref nextCommand, value);
        }
        private IAccountService accountService1;
        private INavigationService navigationService1;
        private bool codeRequested;
        public LoginPhonePageModel(IAccountService accountService, INavigationService navigationService)
        {
            accountService1 = accountService;
            navigationService1 = navigationService;
            NextCommand = new Command(OnNextAction);
        }

        private async void OnNextAction(object obj)
        {
            if (codeRequested)
            {
                var loginAttempt = await accountService1.VerifyOtpCodeAsync(Code);
                if (loginAttempt)
                {
                    await navigationService1.NavigateToAsync<DashboardPageModel>(null, true);
                }
                else
                {

                }
            } else
            {

                CodeSent = await accountService1.SendOtpCodeAsync(PhoneNumber);
                if (!CodeSent){
                    return;
                }
                codeRequested = true;
                ButtonText = "Verify Code";
            }
        }
    }
}
