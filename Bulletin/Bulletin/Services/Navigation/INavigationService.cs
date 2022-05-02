using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bulletin.PageModels.Base;

namespace Bulletin.Services.Navigation
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation Methos to push onto the Navigation Stack
        /// </summary>
        /// <typeparam name="TPageModelBase"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
            where TPageModelBase : PageModelBase;

        /// <summary>
        /// Navigation method to pop off the navigation stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
