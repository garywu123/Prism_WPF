using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    /// <summary>
    ///     A View Model for ViewA
    /// </summary>
    class ViewAViewModel : BindableBase
    {
        public string Title { get; set; } = "Hello from ViewA ViewModel";
    }
}
