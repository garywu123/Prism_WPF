#region License

// author:         吴经纬
// created:        16:50
// description:

#endregion

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

        // 如果返回 true，代表使用之前创建的 View，不然创建一个新的 View 并注入到 Region 当中。
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters.GetValue<Person>("person");

            return SelectedPerson.LastName == person.LastName;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
