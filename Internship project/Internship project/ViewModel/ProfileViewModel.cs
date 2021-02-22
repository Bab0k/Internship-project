using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class ProfileViewModel : BindableBase
    {
        string Photo = "pic_profile.png";

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



        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Profile";
        }


    }
}
