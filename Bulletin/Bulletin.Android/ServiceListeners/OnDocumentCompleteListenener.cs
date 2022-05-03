using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Bulletin.Droid.Extensions;
using Bulletin.Services;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Android.Gms.Tasks.Task;

namespace Bulletin.Droid.ServiceListeners
{
    public class OnDocumentCompleteListenener<T> : Java.Lang.Object, IOnCompleteListener where T : IIdentifiable
    {
        private TaskCompletionSource<T> tcs1;

        public OnDocumentCompleteListenener(TaskCompletionSource<T> tcs)
        {
            tcs1 = tcs;

        }
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                var docObject = task.Result;
                if (docObject is DocumentSnapshot docRef)
                {
                    tcs1.TrySetResult(docRef.Convert<T>());
                    return;
                }
                tcs1.TrySetResult(default);
                return;
            }
            tcs1.TrySetResult(default);
        }
    }
}