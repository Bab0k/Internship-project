using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Internship_project.ViewModel
{
    public class SignUpViewModel : BindableBase, INotifyPropertyChanged
    {
        private DelegateCommand _navigationcommand;
        string Login
        {
            get => Login;
            set
            {
                Login = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Login)));
            }
        }
        string Password
        {
            get  => Password;
            set
            { 
                Password = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Password)));
            }
        }
        string ConfirmUserPassword
        {
            get => ConfirmUserPassword;
            set
            { 
                ConfirmUserPassword = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ConfirmUserPassword)));
            }
        }


        public SignUpViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "SignUp";
        }


        public DelegateCommand NavigationCommand =>
            _navigationcommand ?? (_navigationcommand = new DelegateCommand(ExecuteNavigatioCommand));

        private void ExecuteNavigatioCommand()
        {
            var param = new NavigationParameters();

            param.Add("Login", Login);


            NavigationService.NavigateAsync("MainListView");

        }

    }
}
