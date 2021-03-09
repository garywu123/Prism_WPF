#region License

// author:         吴经纬
// created:        14:26
// description:

#endregion

using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase
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

        // public void OnNavigatedTo(NavigationContext navigationContext)
        // {
        //     PageViews++;
        // }
        //
        // public bool IsNavigationTarget(NavigationContext navigationContext)
        // {
        //     return true;
        // }
        //
        // public void OnNavigatedFrom(NavigationContext navigationContext)
        // {
        // }

        #endregion
    }
}
