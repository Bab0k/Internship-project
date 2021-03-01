using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class ProfileViewModel : ViewModelBase, INavigatedAware
    {
        ImageSource _Photo = ImageSource.FromUri(new Uri("pic_profile.png"));
        public ImageSource Photo
        {
            get => _Photo;
            set
            {
                if (_Photo == value)
                {
                    return;
                }

                _Photo = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Photo)));
            }
        }


        string name = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                {
                    return;
                }

                name = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        string nickname = string.Empty;
        public string NickName
        {
            get => nickname;
            set
            {
                if (nickname == value)
                {
                    return;
                }

                nickname = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(NickName)));
            }
        }

        string description = string.Empty;
        public string Description
        {
            get => description;
            set
            {
                if (description == value)
                {
                    return;
                }

                description = value;

                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Description)));
            }
        }

        private string UserId;

        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Profile";
        }


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            UserId = parameters.GetValue<string>("UserId");
        }
    }
}
