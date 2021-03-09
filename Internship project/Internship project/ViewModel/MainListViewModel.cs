using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
using Internship_project.View;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class MainListViewModel : ViewModelBase, INavigatedAware
    {
        ObservableCollection<Profile> _ProfileList = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> ProfileList
        {
            get => _ProfileList;
            set => SetProperty(ref _ProfileList, value, nameof(ProfileList));
        }
        public string UserId { get { return UserData.User.Id; } }

        public MainListViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "MainPage";
        }

        private void NavigationToMainListView()
        {
            NavigationService.NavigateAsync(nameof(ProfileView));
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ProfileList = new ObservableCollection<Profile>(Realm.GetInstance().All<Profile>().Where(u => u.IdUser == UserId).OrderBy(u => u.Date));
        }

        public DelegateCommand NavigationCommand =>
            new DelegateCommand(NavigationToMainListView);
    }
}
