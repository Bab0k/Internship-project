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
        private byte[] ImageArray;

        ImageSource _Photo = ImageSource.FromFile("pic_profile.png");
        public ImageSource Photo
        {
            get => _Photo;
            set => SetProperty(ref _Photo, value);
        }

        string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        string _nickname = string.Empty;
        public string NickName
        {
            get => _nickname;
            set
            {
                if (_nickname == value)
                {
                    return;
                }

                _nickname = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(NickName)));
            }
        }

        string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Description)));
            }
        }
        public string UserId { get { return UserData.User.Id; } }

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

            ImageArray = GetByteArrayFromStream(file.GetStream());

            Photo = ImageSource.FromStream(() => { return new MemoryStream(ImageArray); });

        }

        private byte[] GetByteArrayFromStream(Stream stream)
        {
            if (stream == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public DelegateCommand PickPhotoCommand =>
             new DelegateCommand(PickPhoto);

        public DelegateCommand SaveData =>
             new DelegateCommand(saveData);

        private void saveData()
        {
            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            _realm.Add(new Profile
            {
                IdUser = UserId,
                File = ImageArray,
                Description = Description,
                Name = Name,
                NickName = NickName,
                Date = DateTime.Now.ToString("MM/dd/yyyy")
            });

            _transaction.Commit();

            _transaction.Dispose();

            NavigationService.GoBackAsync();

        }
    }
}
