using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Internship_project.ViewModel
{
    public class SignInViewModel: BindableBase
    {
        private DelegateCommand _navigationcommand;

        public SignInViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "SignIn";
        }


        public DelegateCommand NavigationToSignUpView =>
            _navigationcommand ?? (_navigationcommand = new DelegateCommand(ExecuteNavigatioCommand));

        private void ExecuteNavigatioCommand()
        {
            NavigationService.NavigateAsync("SignUpView");
        }

    }
}
