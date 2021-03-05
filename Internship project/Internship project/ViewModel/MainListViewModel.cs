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


        ObservableCollection<ProfileBinging> _ProfileList = new ObservableCollection<ProfileBinging>();
        ObservableCollection<ProfileBinging> ProfileList
        {
            get => _ProfileList;
            set => SetProperty(ref _ProfileList, value);
        }
        public string UserId { get { return UserData.User.Id; } }

        public MainListViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "MainPage";
        }

        private void Init()
        {

            CurrentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            CurrentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            CurrentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            
            
            var abs = new AbsoluteLayout();
            abs.Children.Add(new ImageButton()
            {
                Aspect = Aspect.AspectFit,
                BackgroundColor = Color.Blue,
                CornerRadius = 35,
                Command = NavigationCommand,
                Source = "ic_add3x.png",

            }, new Rectangle(.95, .95, 70, 70), AbsoluteLayoutFlags.PositionProportional);

            CurrentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5, GridUnitType.Absolute) });

            abs.Children.Add(CurrentGrid);

            GridContent = new ScrollView() { Content = abs };
        }

        private void NavigationToMainListView()
        {
            NavigationService.NavigateAsync(nameof(ProfileView));
        }

        public DelegateCommand NavigationCommand =>
            new DelegateCommand(NavigationToMainListView);


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
        void INavigatedAware.OnNavigatedTo(INavigationParameters parameters)
        {
            ProfileList = new ObservableCollection<ProfileBinging>();

            foreach (var item in Realm.GetInstance().All<Profile>().Where(u => u.IdUser == UserId))
            {
                ProfileList.Add(new ProfileBinging
                {
                    Id = item.Id,
                    IdUser = item.IdUser,
                    Name = item.Name,
                    NickName = item.NickName,
                    File = ImageSource.FromStream(() => new MemoryStream(item.File))
                });
            }
        }
    }
}
