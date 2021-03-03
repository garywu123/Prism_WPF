#region License

// author:         吴经纬
// created:        14:23
// description:

#endregion

/// <summary>
///     一个用来代表 View A 的模块。在 WPF PRISM 中，每一个 View 都是独立的模块。
/// 该模块的采用的 WPF User Control Lib 模板，需要添加 Nuget Prism WPF。
/// </summary>
using System;
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    /// <summary>
    ///     自定义一个 Module，该 Module 就代表一个 View，每一个 View 都是独立的一个模块。
    /// </summary>
    public class ModuleAModule : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }
    }
}