using Prism.Mvvm;
using PrismDemo.Core.Commands;

namespace PrismTemplateApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
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

            set
            {
                SetProperty(ref _applicationCommands, value);
            }
        }

        public MainWindowViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
        }
    }
}