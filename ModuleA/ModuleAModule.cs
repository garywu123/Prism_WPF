﻿#region License

// author:         吴经纬
// created:        14:23
// description:

#endregion

/// <summary>
///     一个用来代表 View A 的模块。在 WPF PRISM 中，每一个 View 都是独立的模块。
/// 该模块的采用的 WPF User Control Lib 模板，需要添加 Nuget Prism WPF。
/// </summary>
using ModuleA.Controls;
using ModuleA.ViewModels;
using ModuleA.Views;
using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA
{
    /// <summary>
    ///     自定义一个 Module，该 Module 就代表一个 View，每一个 View 都是独立的一个模块。
    /// </summary>
    public class ModuleAModule : IModule
    {
        /// <summary>
        ///     在对应 Module 中添加一个 Region Manager，用来进行 View 与 Region 的注册。
        /// </summary>
        private readonly IRegionManager _regionManager;

        /// <summary>
        ///     构造器，用来初始化 region manager
        /// </summary>
        /// <param name="regionManager">
        ///     <see cref="IRegionManager" />
        /// </param>
        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        ///     当你在 App 中注册了该 Module，它会先实现该方法，将 <see cref="ModuleAModule" /> 注册到 App 的
        ///     catalog map 中。同时，它也是用来定义 View 和 ViewModel 关联的地方。
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 自定义关联，将 Control A 和 ControlAViewModel 关联（因为ControlA没有按照命名规则来）
            // ViewModelLocationProvider.Register<ControlA, ControlAViewModel>();

            // 也可以使用工厂方法，根据 View 来创建对应的 ViewModel
            ViewModelLocationProvider.Register<ControlA>(() => new ControlAViewModel
                {Text = "Hello From Factory."});

            // 注册 View Navigation
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC>();

            containerRegistry.RegisterForNavigation<PersonDetail>();
        }

        /// <summary>
        ///     当 Module 注册完成以后，调用该方法来初始化该 Module，并将 Module 所使用到的 View 与目标 Region 进行绑定。
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // 展示如何将 View 与 Region 捆绑
            SetupViewAWithRegion(containerProvider);

            // 设置 TabView 用来展示组合 Delegate Command
            SetupDelegateCommandView(containerProvider);

            var eventRegion = _regionManager.Regions["EventRegion"];
            eventRegion.Add(containerProvider.Resolve<EventDemoPage>());

            var messageInputRegion = _regionManager.Regions["MessageInputRegion"];
            messageInputRegion.Add(containerProvider.Resolve<MessageInput>());

            var messageListRegion = _regionManager.Regions["MessageListRegion"];
            messageListRegion.Add(containerProvider.Resolve<MessageList>());
        }

        /// <summary>
        /// 展示如何将 View 与 Region 捆绑
        /// </summary>
        /// <param name="containerProvider"> The container provider </param>
        private void SetupViewAWithRegion(IContainerProvider containerProvider)
        {
            // 方法1：通过 View Dependency 将 Region 与 View 绑定
            // _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));

            // 方法2：通过 View Injection 将 View 注入到 Region 中
            var region = _regionManager.Regions["ContentRegion"];
            region.Add(containerProvider.Resolve<ViewA>());

            /*
             * // 创建一个新的 View，修改内容然后添加到 Region 中。
            var view2 = containerProvider.Resolve<ViewA>();
            view2.Content = new TextBlock()
            {
                Text = "Hello From View B",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            region.Add(view2);
            region.Activate(view2);*/
        }

        private void SetupDelegateCommandView(IContainerProvider containerProvider)
        {
            var tabRegion = _regionManager.Regions["TabRegion"];

            // 设置 TabControl 中的子 TabItem
            var tabA = containerProvider.Resolve<TabView>();
            SetTitle(tabA, "Tab A");
            tabRegion.Add(tabA);

            var tabB = containerProvider.Resolve<TabView>();
            SetTitle(tabB, "Tab B");
            tabRegion.Add(tabB);

            var tabC = containerProvider.Resolve<TabView>();
            SetTitle(tabC, "Tab C");
            tabRegion.Add(tabC);
        }

        void SetTitle(TabView tab, string title)
        {
            ((TabViewModel) tab.DataContext).Title = title;
        }
    }
}
