using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Bulletin.PageModels.Base
{
    public class PageModelBase : ExtendedBindableObject
    {
        string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        bool isLoading;

        public bool IsLoading
        {
            get => IsLoading;
            set => SetProperty(ref isLoading, value);
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }
    }
}
