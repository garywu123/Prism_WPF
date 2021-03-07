#region License

// author:         吴经纬
// created:        17:29
// description:

#endregion

using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class ControlAViewModel : BindableBase
    {
        public string Text { get; set; } = "Hello from ControlAViewModel";
    }
}
