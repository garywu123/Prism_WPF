using System.Windows;
using System.Windows.Controls;
using Prism.Ioc;
using Prism.Regions;
using PrismTemplateApp.Core.Regions;
using PrismTemplateApp.Views;

namespace PrismTemplateApp
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        /// <summary>
        ///     该方法用来将你自定义的 <see cref="StackPanelRegionAdapter" /> 注册到系统表中，用来代表 StackPanel
        /// </summary>
        /// <param name="regionAdapterMappings"> Prism 中自带的控件与 Region 的映射表 </param>
        protected override void ConfigureRegionAdapterMappings(
            RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(StackPanel),
                Container.Resolve<StackPanelRegionAdapter>());
        }
    }
}