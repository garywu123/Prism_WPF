#region License

// author:         吴经纬
// created:        16:50
// description:

#endregion

using System;
using Prism.Mvvm;
using Prism.Regions;
using PrismDemo.Core.Business;

namespace ModuleA.ViewModels
{
    public class PersonDetailViewModel : BindableBase, INavigationAware
    {
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        // 获取navigation的参数
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("person"))
                SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }
    }
}
