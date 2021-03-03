using System;
using System.Windows;
using FirstApplication.Views;
using Prism.Ioc;
using Prism.Unity;

namespace FirstApplication
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        /// <summary>
        ///     创建一个 Shell 应用壳体
        /// </summary>
        /// <returns>返回一个窗口</returns>
        protected override Window CreateShell()
        {
            // Container 是 Prism 中的一个属性，类似 IoC 依赖注入，将 ShellWindow 作为泛型传入以后，Container 会创建该 Window 然后返回
            return Container.Resolve<ShellWindow>();
        }
    }
}