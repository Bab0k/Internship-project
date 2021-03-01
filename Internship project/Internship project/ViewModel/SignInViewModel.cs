using Internship_project.Model.Tables;
using Internship_project.View;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class SignInViewModel: ViewModelBase
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

        public bool UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

        private void SignIn_Clicked()
        {
            Realm _realm = Realm.GetInstance();
            var Users = _realm.All<User>();

            if (CheckValidation(Users))
            {
                MainListViewNavigationCommand.Execute();
            }
        }

        private bool CheckValidation(IQueryable<User> users)
        {
            if (users.Where(u => u.Login == Login && u.Password == Password).Any())
            {
                return true;
            }
            Application.Current.MainPage.DisplayAlert("Error", "Missing login or password", "Cancel");

            return false;

        }

        public DelegateCommand MainListViewNavigationCommand =>
                  new DelegateCommand(OnMainListViewNavigationCommand);
        private void OnMainListViewNavigationCommand()
        {
            var param = new NavigationParameters();

            param.Add("Login", Login);

            NavigationService.NavigateAsync(nameof(MainListView), param);

        }

        public DelegateCommand SignUpViewNavigatioCommand =>
             new DelegateCommand(OnSignUpViewNavigatioCommand);
        private void OnSignUpViewNavigatioCommand()
        {
            NavigationService.NavigateAsync(nameof(SignUpView));
        }

        public DelegateCommand CheckSignIn =>
            new DelegateCommand(SignIn_Clicked);
    }
}
