using Prism.Commands;
using Prism.Navigation;
using System.ComponentModel;

namespace Internship_project.ViewModel
{
    public class SignUpViewModel : BindableBase, INotifyPropertyChanged
    {
        private DelegateCommand _navigationcommand;

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
