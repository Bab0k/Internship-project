using Prism.Mvvm;
using Prism.Navigation;

namespace Internship_project.ViewModel
{
    public class ViewModelBase : BindableBase
    {

        protected INavigationService NavigationService { get; private set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
