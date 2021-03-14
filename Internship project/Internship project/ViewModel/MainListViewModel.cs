using Internship_project.Model.Language;
using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
using Internship_project.View;
using Prism.Commands;
using Prism.Navigation;
using Realms;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class MainListViewModel : ViewModelBase, INavigatedAware
    {
        #region Properties

        ObservableCollection<Profile> _ProfileList = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> ProfileList
        {
            get => _ProfileList;
            set => SetProperty(ref _ProfileList, value);
        }
        Profile _SelectedProfile;
        public Profile SelectedProfile
        {
            get => _SelectedProfile;
            set => SetProperty(ref _SelectedProfile, value);
        }
        bool _IsVisibleImage = false;
        public bool IsVisibleImage
        {
            get => _IsVisibleImage;
            set => SetProperty(ref _IsVisibleImage, value);
        }
        string _SelectedImagePath;
        public string SelectedImagePath
        {
            get => _SelectedImagePath;
            set => SetProperty(ref _SelectedImagePath, value);
        }

        public string UserId { get { return UserData.User.Id; } }

        Base.MainList _Language;
        public Base.MainList Language
        {
            get => _Language;
            set => SetProperty(ref _Language, value);
        }


        string Edit { get; set; }
        string Delete { get; set; }

        #endregion

        public MainListViewModel(INavigationService navigationService) : base(navigationService)
        {
            Language = UserData.settings.GetLanguage().mainList;

            Title = Language.Title;
        }

        private void _NavigationToProfile()
        {
            NavigationService.NavigateAsync(nameof(ProfileView));
        }
        private void _NavigationToSettings()
        {
            NavigationService.NavigateAsync(nameof(SettingsView));
        }
        private void Logout()
        {
            UserData.User = null;
            NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(SignInView)}");
        }

        private void Tap()
        {
            SelectedImagePath = SelectedProfile.Path;
            IsVisibleImage = true;
        }
        private void TapScrean()
        {
            IsVisibleImage = false;
        }

        public void EditItem(Profile profile)
        {
            NavigationParameters param = new NavigationParameters
            {
                { "CurrentProfile", profile }
            };

            NavigationService.NavigateAsync(nameof(ProfileView), param);
        }
        public void DeleteItem(Profile profile)
        {
            var _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            _realm.Remove(profile);

            _transaction.Commit();
            _transaction.Dispose();

            ProfileList = UserData.settings.OrderBy(new ObservableCollection<Profile>(Realm.GetInstance().All<Profile>().Where(u => u.IdUser == UserId)));
        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ProfileList = UserData.settings.OrderBy(new ObservableCollection<Profile>(Realm.GetInstance().All<Profile>().Where(u => u.IdUser == UserId)));
        }

        public DelegateCommand NavigationToProfile =>
            new DelegateCommand(_NavigationToProfile);
        public DelegateCommand NavigationToSettings =>
            new DelegateCommand(_NavigationToSettings);
        public DelegateCommand LogoutCommand =>
            new DelegateCommand(Logout);
        public DelegateCommand TapCommand =>
            new DelegateCommand(Tap);
        public DelegateCommand TapScreanCommand =>
            new DelegateCommand(TapScrean);
    }
}
