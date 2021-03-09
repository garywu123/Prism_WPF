#region License

// author:         吴经纬
// created:        14:27
// description:

#endregion

using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismDemo.Core.Business;

namespace ModuleA.ViewModels
{
    /// <summary>
    ///     用来作为 View C 的 VM
    /// </summary>
    public class ViewCViewModel : BindableBase, INavigationAware
    {
        private string _text = "ViewC";
        private int _pageViews;
        private readonly IRegionManager _regionManager;
        private ObservableCollection<Person> _people;


        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public int PageViews
        {
            get => _pageViews;

            set => SetProperty(ref _pageViews, value);
        }

        public ObservableCollection<Person> People
        {
            get => _people;
            set => SetProperty(ref _people, value);
        }

        public DelegateCommand<Person> PersonSelectedCommand { get; }

        public ViewCViewModel(IRegionManager regionManager)
        {
            PersonSelectedCommand = new DelegateCommand<Person>(ExecutePersonSelected);
            CreatePeople();
            _regionManager = regionManager;
        }

        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();
            for (var i = 0; i < 10; i++)
                people.Add(new Person
                {
                    FirstName = $"First {i}",
                    LastName = $"Last {i}",
                    Age = i
                });

            People = people;
        }

        private void ExecutePersonSelected(Person person)
        {
            if (person == null) return;

            var parameter = new NavigationParameters {{"person", person}};

            _regionManager.RequestNavigate("PersonDetailsRegion", "PersonDetail",
                parameter);
        }

        #region Navigation Callback Method

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        #endregion
    }
}
