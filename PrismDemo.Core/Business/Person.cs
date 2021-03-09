#region License

// author:         吴经纬
// created:        16:41
// description:

#endregion

using Prism.Mvvm;

namespace PrismDemo.Core.Business
{
    public class Person : BindableBase
    {
        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        private int _age;

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
