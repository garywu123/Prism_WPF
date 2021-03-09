#region License
// author:         吴经纬
// created:        14:46
// description:
#endregion

using ModuleB.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {

        private readonly IRegionManager _regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // _regionManager.RegisterViewWithRegion("MessageListRegion", typeof(MessageList));
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            throw new System.NotImplementedException();
        }
    }
}
