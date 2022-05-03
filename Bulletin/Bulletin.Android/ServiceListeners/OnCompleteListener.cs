using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bulletin.Models;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulletin.Droid.ServiceListeners
{
    public  class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<AuthenticatedUser> tcs1;
        public OnCompleteListener(TaskCompletionSource<AuthenticatedUser> tcs)
        {
            tcs1 = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if(task.IsSuccessful)
            {
                var result = task.Result;
                if (result is DocumentSnapshot doc)
                {
                    var user = new AuthenticatedUser();
                    user.Id = doc.Id;
                    user.FirstName = doc.GetString("FirstName");
                    user.LastName = doc.GetString("LastName");
                    tcs1.TrySetResult(user);
                    return;
                }
            }
            tcs1.TrySetResult(default(AuthenticatedUser));
        }
    }
}