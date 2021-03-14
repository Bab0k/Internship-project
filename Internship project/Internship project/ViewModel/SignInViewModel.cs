using Internship_project.Model.Language;
using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
using Internship_project.View;
using Prism.Commands;
using Prism.Navigation;
using Realms;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class SignInViewModel: ViewModelBase, INavigationAware
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
            get => password;
            set => SetProperty(ref password, value);
        }

        Base.SignIn _Language;
        public Base.SignIn Language
        {
            get => _Language;
            set => SetProperty(ref _Language, value);
        }

        public string SigninButton { get; set; }
        public string SignupButton { get; set; }
        public string LoginPlaceHolder { get; set; }
        public string PasswordPlaceHolder { get; set; }

        #endregion
        public SignInViewModel(INavigationService navigationService) : base(navigationService)
        {
            Language = UserData.settings.GetLanguage().signIn;
            SigninButton = Language.Signin;
            SignupButton = Language.Signup;
            LoginPlaceHolder = Language.Login;
            PasswordPlaceHolder = Language.Password;
            Title = Language.Title;
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
            Application.Current.MainPage.DisplayAlert(Language.Error, Language.MissingLoginOrPassword, Language.Cancel);

            return false;
        }

        private void OnMainListViewNavigationCommand()
        {
            NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainListView)}");
        }

        private void OnSignUpViewNavigatioCommand()
        {
            NavigationService.NavigateAsync(nameof(SignUpView));
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            string login;
            if (parameters.TryGetValue<string>("Login", out login))
            {
                Login = login;
            }
            string password;
            if (parameters.TryGetValue<string>("Password", out password))
            {
                Password = password;
            }
        }   

        public DelegateCommand SignUpViewNavigatioCommand =>
            new DelegateCommand(OnSignUpViewNavigatioCommand);
        public DelegateCommand MainListViewNavigationCommand =>
            new DelegateCommand(OnMainListViewNavigationCommand);
        public DelegateCommand CheckSignIn =>
            new DelegateCommand(SignIn_Clicked);
    }
}
