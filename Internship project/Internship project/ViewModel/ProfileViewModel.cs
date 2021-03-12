using Internship_project.Model.Language;
using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
using Plugin.Media;
using Prism.Commands;
using Prism.Navigation;
using Realms;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class ProfileViewModel : ViewModelBase, INavigatedAware
    {
        #region Properties

        string _Path = "pic_profile";
        public string Path
        {
            get => _Path;
            set => SetProperty(ref _Path, value, nameof(Path));
        }

        string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }

        string _nickname = string.Empty;
        public string NickName
        {
            get => _nickname;
            set => SetProperty(ref _nickname, value, nameof(NickName));
        }

        string _description = string.Empty;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value, nameof(Description));
        }
        public string UserId { get { return UserData.User.Id; } }

        Profile CurrentProfile = null;

        Base.Profile _Language;
        public Base.Profile Language
        {
            get => _Language;
            set => SetProperty(ref _Language, value);
        }
        public string NamePlaceHolder { get; set; }
        public string NickNamePlaceHolder { get; set; }
        public string DescriptionPlaceHolder { get; set; }

        #endregion

        public ProfileViewModel(INavigationService navigationService) : base(navigationService) 
        {
            Language = UserData.settings.GetLanguage().profile;

            NamePlaceHolder = Language.Name;
            NickNamePlaceHolder = Language.NickName;
            DescriptionPlaceHolder = Language.Description;
            Title = Language.Title;
        }

        private async void PickPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;


            Path = file.Path;
        }
        private void saveData()
        {
            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            if (CurrentProfile != null)
            {
                CurrentProfile.Path = Path;
                CurrentProfile.Name = Name;
                CurrentProfile.NickName = NickName;
                CurrentProfile.Description = Description;

                _realm.Add(CurrentProfile, true);
            }
            else
            {
                _realm.Add(new Profile
                {
                    IdUser = UserId,
                    Path = Path,
                    Description = Description,
                    Name = Name,
                    NickName = NickName,
                    Date = DateTime.Now.ToString()
                });
            }

            _transaction.Commit();
            _transaction.Dispose();

            NavigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("CurrentProfile"))
            {
                Profile item = parameters.GetValue<Profile>("CurrentProfile");

                Name = item.Name;
                NickName = item.NickName;
                Description = item.Description;
                Path = item.Path;

                CurrentProfile = item;
            }

        }

        public DelegateCommand PickPhotoCommand =>
             new DelegateCommand(PickPhoto);

        public DelegateCommand SaveData =>
             new DelegateCommand(saveData);
    }
}
