using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internship_project.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Settings";
        }
    }
}
