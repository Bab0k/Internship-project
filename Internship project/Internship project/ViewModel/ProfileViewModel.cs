using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class ProfileViewModel : BindableBase
    {
        string Photo = "pic_profile.png";
        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Profile";
        }



    }
}
