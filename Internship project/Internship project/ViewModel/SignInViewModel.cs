using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
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
            set => SetProperty(ref login, value);

        }

        string password = string.Empty;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
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
                UserData.User = Realm.GetInstance().All<User>().Where(u => u.Login == Login).First();

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
            NavigationService.NavigateAsync(nameof(MainListView));
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
