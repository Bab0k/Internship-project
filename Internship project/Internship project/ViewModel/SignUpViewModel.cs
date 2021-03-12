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
using Internship_project.Model.Language;

namespace Internship_project.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        #region Properties

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

        Base.SignUp _Language;
        public Base.SignUp Language
        {
            get => _Language;
            set => SetProperty(ref _Language, value);
        }

        public string SignupButton { get; set; }
        public string LoginPlaceHolder { get; set; }
        public string PasswordPlaceHolder { get; set; }
        public string ConfirmPasswordPlaceHolder { get; set; }

        #endregion

        public SignUpViewModel(INavigationService navigationService) : base(navigationService)
        {
            Language = UserData.settings.GetLanguage().signUp;

            SignupButton = Language.Signup;
            LoginPlaceHolder = Language.Login;
            PasswordPlaceHolder = Language.Password;
            ConfirmPasswordPlaceHolder = Language.ConfirmPassword;
            Title = Language.Title;
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
                Application.Current.MainPage.DisplayAlert(Language.Error, Language.LoginExist, Language.Cancel);

                return false;
            }
            if (!Validation.Validation.IsLogin(Login))
            {
                Application.Current.MainPage.DisplayAlert(Language.Error, Language.LoginNonValidation, Language.Cancel);
                return false;
            }
            if (!Validation.Validation.IsPassword(Password))
            {
                Application.Current.MainPage.DisplayAlert(Language.Error, Language.PasswordNonValidation, Language.Cancel);
                return false;
            }
            if (Password != ConfirmUserPassword)
            {
                Application.Current.MainPage.DisplayAlert(Language.Error, Language.PasswordMismatch, Language.Cancel);

                return false;
            }
            return true;
        }


        private void NavigationToMainListView()
        {
            NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainListView)}");
        }

        public DelegateCommand CheckSignUp =>
            new DelegateCommand(SignUp_Clicked);

        public DelegateCommand NavigationCommand =>
            new DelegateCommand(NavigationToMainListView);


    }
}
