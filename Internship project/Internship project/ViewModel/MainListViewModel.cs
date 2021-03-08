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
    public class MainListViewModel : ViewModelBase
    {
        Xamarin.Forms.View _GridContent;
        public Xamarin.Forms.View GridContent
        {
            get => _GridContent;
            set
            {
                if (_GridContent == value)
                {
                    return;
                }

                _GridContent = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(GridContent)));
            }
        }

        Grid _Grid = new Grid();
        Grid CurrentGrid
        {
            get => _Grid;
            set
            {
                if (_Grid == value)
                {
                    return;
                }

                _Grid = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentGrid)));
            }
        }


        ObservableCollection<Profile> _ProfileList = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> ProfileList
        {
            get => _ProfileList;
            set
            {
                if (ProfileList == value)
                {
                    return;
                }
                _ProfileList = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ProfileList)));
            }
        }
        public string UserId { get { return UserData.User.Id; } }

        public MainListViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "MainPage";

            ProfileList = new ObservableCollection<Profile>(Realm.GetInstance().All<Profile>().Where(u => u.IdUser == UserId).OrderBy(u => u.Date));
        }

        private void NavigationToMainListView()
        {
            NavigationService.NavigateAsync(nameof(ProfileView));
        }

        public DelegateCommand NavigationCommand =>
            new DelegateCommand(NavigationToMainListView);
    }
}
