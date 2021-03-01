﻿using Internship_project.Model.Tables;
using Prism.Commands;
using Prism.Navigation;
using Realms;
using System;
using System.ComponentModel;
using System.Linq;
using Internship_project.Validation;
using Xamarin.Forms;
using Internship_project.View;

namespace Internship_project.ViewModel
{
    public class SignUpViewModel : ViewModelBase, INotifyPropertyChanged
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
            get  => password;
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

        string confirmUserPassword = string.Empty;
        public string ConfirmUserPassword
        {
            get => confirmUserPassword;
            set
            {
                if (confirmUserPassword == value)
                {
                    return;
                }
                confirmUserPassword = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ConfirmUserPassword)));
            }
        }

        public SignUpViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "SignUp";
        }

        private void SignUp_Clicked()
        {
            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();
            var Users = _realm.All<User>();

            if (CheckValidation(Users))
            {
                _realm.Add(new User
                {
                    Login = Login,
                    Password = Password
                });

                NavigationCommand.Execute();
            }

            _transaction.Commit();
            _transaction.Dispose();
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
            var param = new NavigationParameters();

            param.Add("Login", Login);

            NavigationService.NavigateAsync(nameof(MainListView), param);

        }

        public DelegateCommand CheckSignUp =>
            new DelegateCommand(SignUp_Clicked);

        public DelegateCommand NavigationCommand =>
            new DelegateCommand(NavigationToMainListView);


    }
}
