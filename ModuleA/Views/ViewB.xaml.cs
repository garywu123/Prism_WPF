using System.Windows.Controls;
using Prism.Regions;

namespace ModuleA.Views
{
    /// <summary>
    ///     Interaction logic for ViewB.xaml
    /// </summary>
    public partial class ViewB : UserControl, INavigationAware
    {
        private int _viewCount;

        public ViewB()
        {
            InitializeComponent();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _viewCount++;
            textBlock.Text = _viewCount.ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
