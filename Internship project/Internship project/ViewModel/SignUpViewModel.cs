using Internship_project.Model.Tables;
using Prism.Commands;
using Prism.Navigation;
using Realms;
using System;
using System.ComponentModel;
using System.Linq;
using Internship_project.Validation;
using Xamarin.Forms;
using Internship_project.View;
using Internship_project.Model.UserData;

namespace Internship_project.ViewModel
{
    public class SignUpViewModel : ViewModelBase, INotifyPropertyChanged
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
            get  => password;
            set => SetProperty(ref password, value);
        }

        string confirmUserPassword = string.Empty;
        public string ConfirmUserPassword
        {
            get => confirmUserPassword;
            set => SetProperty(ref confirmUserPassword, value);
        }

        public SignUpViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "SignUp";
        }

        private void SignUp_Clicked()
        {
            Realm _realm = Realm.GetInstance();
            var Users = _realm.All<User>();

            if (CheckValidation(Users))
            {
                Transaction _transaction = _realm.BeginWrite();

                _realm.Add(new User
                {
                    Login = Login,
                    Password = Password
                });

                UserData.User = Realm.GetInstance().All<User>().Where(u => u.Login == Login).First();

                _transaction.Commit();
                _transaction.Dispose();

                NavigationCommand.Execute();
            }

        }
        public bool UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmUserPassword);
        }

        private bool CheckValidation(IQueryable<User> users)
        {
            
            if (users.Where(u => u.Login == Login).Any())
            {
                Application.Current.MainPage.DisplayAlert("Error", "this login exists", "Cancel");

                return false;
            }
            if (!Validation.Validation.IsLogin(Login))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Login be at least 4 and no more then 16 " +
                    "and starting at letter", "Cancel");
                return false;
            }
            if (!Validation.Validation.IsPassword(Password))
            {
                Application.Current.MainPage.DisplayAlert("Error", "Password be at least 4 and no more then 16" +
                    "and must contain at least one uppercase letter," +
                    "one  lovercase letter and one number", "Cancel");
                return false;
            }
            if (Password != ConfirmUserPassword)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Password mismatch", "Cancel");

                return false;
            }
            return true;
        }


        private void NavigationToMainListView()
        {
            NavigationService.NavigateAsync(nameof(MainListView));
        }

        public DelegateCommand CheckSignUp =>
            new DelegateCommand(SignUp_Clicked);

        public DelegateCommand NavigationCommand =>
            new DelegateCommand(NavigationToMainListView);


    }
}
