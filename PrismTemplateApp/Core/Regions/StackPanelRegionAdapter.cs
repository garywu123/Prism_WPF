#region License

// author:         吴经纬
// created:        13:46
// description:

#endregion

using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace PrismTemplateApp.Core.Regions
{
    /// <summary>
    ///     一个自定义的 StackPanelRegion，可以将一个普通的控件 StackPanel 转为一个 Region 从而可以被添加到 Prism 中的
    ///     ContentControl 中
    /// </summary>
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        /// <summary>
        ///     必须实现的方法，用来创建 <see cref="RegionBehaviorFactory" />
        /// </summary>
        /// <param name="regionBehaviorFactory"> Region 行为工厂 </param>
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(
            regionBehaviorFactory)
        {
        }

        /// <summary>
        ///     该方法用来将传入的 View 转为 StackPanel。每当你所定义的 Region 绑定的 Content
        ///     列表发生变化，就会调用对应的事件，像你所定义的 StackPanel 中添加、删除对应的 target
        /// </summary>
        /// <param name="region">你在 xaml 中定义的 region</param>
        /// <param name="regionTarget">
        ///     目标控件，比如你想将 StackPanel 转为一个 Region，那你的 regionTarget
        ///     就是 StackPanel
        /// </param>
        protected override void Adapt(IRegion region, StackPanel regionTarget)
        { 
            // 当region 的 Views 集合发生改变
            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    // 如果添加一个新的 View 到集合中
                    case NotifyCollectionChangedAction.Add:
                    {
                        // 将所有控件添加到 StackPanel 中
                        foreach (FrameworkElement item in e.NewItems)
                            regionTarget.Children.Add(item);

                        break;
                    }
                    case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (FrameworkElement item in e.OldItems)
                            regionTarget.Children.Remove(item);

                        break;
                    }
                    case NotifyCollectionChangedAction.Replace:
                        break;
                    case NotifyCollectionChangedAction.Move:
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            };
        }


        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}