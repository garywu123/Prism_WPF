#region License

// author:         吴经纬
// created:        14:26
// description:

#endregion

using Prism.Mvvm;

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
    }
}
