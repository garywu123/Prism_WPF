using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    /// <summary>
    ///     A View Model for ViewA
    /// </summary>
    internal class ViewAViewModel : BindableBase
    {
        private string _title = "Hello from ViewA ViewModel";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        ///     True if the project has been changed and allowed to save the project
        /// </summary>
        private bool _isDirty = false;

        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                // ReSharper disable once ArrangeAccessorOwnerBody
                SetProperty(ref _isDirty, value);
                // 通知 UI，SaveButton 的状态发生改变
                // SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string OkButtonText { get; set; } = "Click Me";
        public string SaveButtonText { get; set; } = "Save";

        public DelegateCommand ClickCommand { get; }
        public DelegateCommand SaveCommand { get; }

        public ViewAViewModel()
        {
            ClickCommand = new DelegateCommand(ClickExecutionMethod, CanClick);

            // 让 Save 按钮监视 IsDirty 属性
            // SaveCommand = new DelegateCommand(SaveExecutionMethod, CanSave)
            //     .ObservesProperty(() => IsDirty);

            // 也可以用来监控 CanSave，通过这个，你不需要再实现 CanExecute 方法
            SaveCommand =
                new DelegateCommand(SaveExecutionMethod)
                    .ObservesCanExecute(() => IsDirty);
        }


        private void SaveExecutionMethod()
        {
            MessageBox.Show("Project saved.");
        }

        private bool CanClick()
        {
            return true;
        }

        private void ClickExecutionMethod()
        {
            Title = "View A ViewModel Title Changed by ClickMe Button";
            IsDirty = true;
        }
    }
}
