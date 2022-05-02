using Bulletin.Services.Account;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Firebase.Auth;
using Xamarin.Forms;
using Bulletin.iOS.Services;

[assembly: Dependency(typeof(AccountService))]
namespace Bulletin.iOS.Services
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {

        }
        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10d);
        }
        public Task<bool> LoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            Auth.DefaultInstance.SignInWithPasswordAsync(username, password).ContinueWith((task) => OnAuthCompleted(task, tcs));
            return tcs.Task;
        }

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                tcs.SetResult(false);
                return;
            }
            tcs.SetResult(true);
        }
    }
    
}