#region License

// author:         吴经纬
// created:        20:27
// description:

#endregion

using System;
using Prism.Commands;
using Prism.Mvvm;
using PrismDemo.Core.Commands;

namespace ModuleA.ViewModels
{
    public class TabViewModel : BindableBase
    {
        #region Public Property

        private string _title;

        public string Title
        {
            get => _title;

            set => SetProperty(ref _title, value);
        }

        private bool _canUpdate = false;

        public bool CanUpdate
        {
            get => _canUpdate;

            set => SetProperty(ref _canUpdate, value);
        }

        private string _updateText;

        public string UpdateText
        {
            get => _updateText;

            set => SetProperty(ref _updateText, value);
        }

        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ??= new DelegateCommand(ExecuteUpdateCommand).ObservesCanExecute(()=>CanUpdate);

        #endregion


        private void ExecuteUpdateCommand()
        {
            UpdateText = $"Updated at: {DateTime.Now}";
        }

        
        public TabViewModel(IApplicationCommands applicationCommands)
        {
            // 将 TabView 中的 UpdateCommand 注册到 ApplicationCommands 中的 SaveAllCommand 中
            applicationCommands.SaveAllCommand.RegisterCommand(UpdateCommand);
        }
    }
}
