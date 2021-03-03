#region License

// author:         吴经纬
// created:        14:23
// description:

#endregion

/// <summary>
///     一个用来代表 View A 的模块。在 WPF PRISM 中，每一个 View 都是独立的模块。
/// 该模块的采用的 WPF User Control Lib 模板，需要添加 Nuget Prism WPF。
/// </summary>
using Prism.Ioc;
using Prism.Modularity;

namespace ModuleA
{
    /// <summary>
    ///     自定义一个 Module，该 Module 就代表一个 View，每一个 View 都是独立的一个模块。
    /// </summary>
    public class ModuleAModule : IModule
    {
        /// <summary>
        ///     当你在 App 中注册了该 Module，它会先实现该方法，将 <see cref="ModuleAModule" /> 注册到 App 的
        ///     catalog map 中。
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        /// <summary>
        ///     当 Module 注册完成以后，调用该方法来初始化该 Module。
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}