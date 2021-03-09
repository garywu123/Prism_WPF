using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismDemo.Core.Commands;

namespace PrismTemplateApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string _title = "Prism Application";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private IApplicationCommands _applicationCommands;

        public IApplicationCommands ApplicationCommands
        {
            get => _applicationCommands;

            set => SetProperty(ref _applicationCommands, value);
        }

        /// <summary>
        ///     用于导航命令
        /// </summary>
        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainWindowViewModel(IApplicationCommands applicationCommands,
                                   IRegionManager regionManager)
        {
            ApplicationCommands = applicationCommands;
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(ExecuteNavigate);
        }

        /// <summary>
        ///     用于执行具体的 View 导航逻辑
        /// </summary>
        /// <param name="uri">注册 View 的时候，给 View 的命名，可以通过 CommandParameter 传入 </param>
        private void ExecuteNavigate(string uri)
        {
            _regionManager.RequestNavigate("NavigationRegion", uri);
        }
    }
}
