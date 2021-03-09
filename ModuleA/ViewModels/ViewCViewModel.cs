#region License

// author:         吴经纬
// created:        14:27
// description:

#endregion

using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    /// <summary>
    ///    用来作为 View C 的 VM
    /// </summary>
    public class ViewCViewModel : BindableBase
    {
        private string _text = "ViewC";

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
