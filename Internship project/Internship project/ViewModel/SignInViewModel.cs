using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Internship_project.ViewModel
{
    public class SignInViewModel: BindableBase
    {

        string login = string.Empty;
        public string Login
        {
            get => login;
            set
            {
                if (login == value)
                {
                    return;
                }

                login = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Login)));
            }
        }

        string password = string.Empty;
        public string Password
        {
            get => password;
            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Password)));
            }
        }


        public SignInViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "SignIn";
        }



        public DelegateCommand MainListViewNavigationCommand =>
                  new DelegateCommand(OnMainListViewNavigationCommand);

        private void OnMainListViewNavigationCommand()
        {
            var param = new NavigationParameters();

            param.Add("Login", Login);

            NavigationService.NavigateAsync("MainListView");

        }

        public DelegateCommand SignUpViewNavigatioCommand =>
             new DelegateCommand(OnSignUpViewNavigatioCommand);

        private void OnSignUpViewNavigatioCommand()
        {
            NavigationService.NavigateAsync("SignUpView");
        }

    }
}
