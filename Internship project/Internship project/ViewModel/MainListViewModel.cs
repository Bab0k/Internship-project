using Internship_project.Model.Tables;
using Internship_project.View;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Realms;
using System;
using System.Collections.Generic;
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

        public string UserId;

        public MainListViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "MainPage";

            Init();
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

        private void GridInit()
        {
            Realm _realm = Realm.GetInstance();
            var Profiles = _realm.All<Profile>().Where(u => u.Id == UserId);
            int i = 0;
            foreach (var item in Profiles)
            {
                CurrentGrid.Children.Add(new Image()
                {
                    Source = ImageSource.FromStream(() => { return new MemoryStream(item.File); }),
                    VerticalOptions = LayoutOptions.CenterAndExpand
                }, 0, i);
                StackLayout stackLayout = new StackLayout() { VerticalOptions = LayoutOptions.CenterAndExpand };
                stackLayout.Children.Add(new Label() { Text = item.NickName });
                stackLayout.Children.Add(new Label() { Text = item.Name });
                stackLayout.Children.Add(new Label() { Text = item.Date });
                CurrentGrid.Children.Add(stackLayout, 1, i++);

                CurrentGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            }
        }


        private void NavigationToMainListView()
        {
            var param = new NavigationParameters();

            param.Add("UserId", UserId);

            NavigationService.NavigateAsync(nameof(ProfileView), param);

        }
        public DelegateCommand NavigationCommand =>
            new DelegateCommand(NavigationToMainListView);


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
        void INavigatedAware.OnNavigatedTo(INavigationParameters parameters)
        {
            string Login = parameters.GetValue<string>("Login");

            Realm _realm = Realm.GetInstance();
            var CurrentUser = _realm.All<User>().Where(u => u.Login == Login).First();

            UserId = CurrentUser.Id;

            GridInit();

        }
    }
}
