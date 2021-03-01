using Internship_project.Model.Tables;
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

        public MainListViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "MainPage";

            GridInit();
        }

        private void GridInit()
        {
            Grid grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
                Margin = 5,
            };

            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();
            var Profiles = _realm.All<Profile>();
            int i = 0;
            foreach (var item in Profiles)
            {
                grid.Children.Add(new Image() { Source = ImageSource.FromStream(() => { return new MemoryStream(item.File); }),
                                                VerticalOptions = LayoutOptions.CenterAndExpand }, 0, i);
                StackLayout stackLayout = new StackLayout() { VerticalOptions = LayoutOptions.CenterAndExpand };
                stackLayout.Children.Add(new Label() { Text = item.NickName });
                stackLayout.Children.Add(new Label() { Text = item.Name });
                stackLayout.Children.Add(new Label() { Text = item.Date });
                grid.Children.Add(stackLayout, 1, i++);

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });
            }

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(5, GridUnitType.Absolute) });
            GridContent = new ScrollView() { Content = grid };
        }
    }
}
