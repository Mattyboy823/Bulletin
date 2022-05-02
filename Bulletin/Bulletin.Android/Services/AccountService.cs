using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bulletin.Droid.Services;
using Bulletin.Services.Account;
using Firebase;
using Firebase.Auth;
using Java.Util.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly:Dependency(typeof(AccountService))]
namespace Bulletin.Droid.Services
{
    public class AccountService :PhoneAuthProvider.OnVerificationStateChangedCallbacks, IAccountService
    {
        const int OTP_TIMEOUT = 30;
        private TaskCompletionSource<bool> phoneAuthTcs;
        private string verificationId1;

        public AccountService()
        {

        }
        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10d);
        }
        public Task<bool>   LoginAsync (string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username, password).ContinueWith((task) => OnAuthCompleted(task, tcs));
            return tcs.Task;
        }

        public override void OnVerificationCompleted(PhoneAuthCredential p0)
        {
            System.Diagnostics.Debug.WriteLine("PhoneAuthCredential created Automatically");
        }

        public override void OnVerificationFailed(FirebaseException p0)
        {
            System.Diagnostics.Debug.WriteLine("verification Failed: " + p0.Message);
            phoneAuthTcs?.TrySetResult(false);

        }
        public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken forceResending)
        {
            base.OnCodeSent(verificationId, forceResending);
            verificationId1 = verificationId;
            phoneAuthTcs?.TrySetResult(true); 
        }
        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                tcs.SetResult(false);
                return;
            }
            verificationId1 = null;
            tcs.SetResult(true);
        }

        Task<bool> IAccountService.SendOtpCodeAsync(string phoneNumber)
        {
            phoneAuthTcs = new TaskCompletionSource<bool>();
            PhoneAuthProvider.Instance.VerifyPhoneNumber(phoneNumber, OTP_TIMEOUT, TimeUnit.Seconds, Platform.CurrentActivity, this);
            return phoneAuthTcs.Task;
        }

        Task<bool> IAccountService.VerifyOtpCodeAsync(string code)
        {
            if (!string.IsNullOrWhiteSpace(verificationId1))
            {
                var credential = PhoneAuthProvider.GetCredential(verificationId1, code);
                var tcs = new TaskCompletionSource<bool>();
                FirebaseAuth.Instance.SignInWithCredentialAsync(credential).ContinueWith((task)=> OnAuthCompleted(task, tcs));
                return tcs.Task;
            }
            return Task.FromResult(false);
        }
    }
}