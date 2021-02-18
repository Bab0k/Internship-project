using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internship_project.ViewModel
{
    public class SignUpViewModel : BindableBase
    {
        private readonly INavigationService navigationService;
        private DelegateCommand _navigationcommand;

        public SignUpViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "SignUp";
            this.navigationService = navigationService;
        }


        public DelegateCommand NavigationCommand =>
            _navigationcommand ?? (_navigationcommand = new DelegateCommand(ExecuteNavigatioCommand));

        private void ExecuteNavigatioCommand()
        {

        }

    }
}
