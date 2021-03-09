using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
using Plugin.Media;
using Prism.Commands;
using Prism.Navigation;
using Realms;
using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class ProfileViewModel : ViewModelBase
    {
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
        Profile NewProfile;

        public ProfileViewModel(INavigationService navigationService) : base(navigationService) 
        {
            Title = "Profile";
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

        public DelegateCommand PickPhotoCommand =>
             new DelegateCommand(PickPhoto);

        public DelegateCommand SaveData =>
             new DelegateCommand(saveData);

        private void saveData()
        {
            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            NewProfile = new Profile
            {
                IdUser = UserId,
                Path = Path,
                Description = Description,
                Name = Name,
                NickName = NickName,
                Date = DateTime.Now.ToString()
            };

            _realm.Add(NewProfile);

            _transaction.Commit();

            _transaction.Dispose();

            NavigationService.GoBackAsync();

        }
    }
}
