using System.Windows;
using System.Windows.Controls;
using ModuleA;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismDemo.Core.Commands;
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
            // 当需要使用 IApplicationCommands 的时候，创建 ApplicationCommands 单例
            containerRegistry
                .RegisterSingleton<IApplicationCommands, ApplicationCommands>();
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

        #region 注册 Modules

        /// <summary>
        ///     使用代码将 Module 注册到 Application 的 Catalog 中
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
        
            // 这一步，就是将 Module A 注册到 App 的 Catalog 中，这样 App 就能够使用该 Module。
            moduleCatalog.AddModule<ModuleAModule>();
        }

        /* 使用其他方式注册
         * /// <summary>
        ///     通过直接指定 Module 的地址来注册 Module 到 Catalog 中。
        /// </summary>
        /// <returns> 返回一个 Module Catalog </returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            // 注意，我们这里使用的路径是 PrismTemplateApp 项目下的 Modules 文件夹，但 Module 本身在另外一个项目中。
            // 要能够过去到该 Module，需要在 ModuleA 的 BuildEvents 当中，创建 Build 脚本，使其在 Build 的时候，将对应的 dll
            // 复制到 PrismTemplateApp 下的 Modules 文件夹
            return new DirectoryModuleCatalog {ModulePath = @".\Modules"};
        }

        // 使用App.config 指定 Module 然后注册，注意，App.config 中定义的 Module 必须在 输出根目录中，
        // 而不是再 Modules 文件夹中。
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }*/

        #endregion
    }
}
