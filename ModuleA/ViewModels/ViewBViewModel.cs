#region License

// author:         吴经纬
// created:        14:26
// description:

#endregion

using System;
using System.Windows;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase, IConfirmNavigationRequest
    {
        private string _text = "ViewB";

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private int _pageViews;

        public int PageViews
        {
            get => _pageViews;

            set => SetProperty(ref _pageViews, value);
        }


        #region Navigation Callback Method

        /*
         * 如果实现 IConfirmNavigationRequest 就不用实现 INavigationAware
         */

        #endregion

        #region Confirm Navigation Callback

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <summary>
        ///     用来确认是否可以进行 Navigation 的方法
        /// </summary>
        /// <param name="navigationContext"> Navigation 的上下文 </param>
        /// <param name="continuationCallback">
        ///     在接收到结果后，将结果作为参数传入该 callback方法，执行该 callback
        ///     方法
        /// </param>
        public void ConfirmNavigationRequest(NavigationContext navigationContext,
                                             Action<bool> continuationCallback)
        {
            // 如果 用户选择 No
            var result = MessageBox.Show("Do you want to navigate?", "Navigate?",
                MessageBoxButton.YesNo) != MessageBoxResult.No;

            // 将 结果传给 callback 方法，如果为 false，则不会导航
            continuationCallback(result);
        }

        #endregion
    }
}
