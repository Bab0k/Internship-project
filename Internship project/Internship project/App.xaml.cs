using Prism;
using Prism.Unity;
using Prism.Modularity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Ioc;
using Prism.Navigation;
using Internship_project.View;
using Internship_project.ViewModel;

namespace Internship_project
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null): base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            

            NavigationService.NavigateAsync("NavigationPage/SignInView");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInView, SignInViewModel>();
            containerRegistry.RegisterForNavigation<SignUpView, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<ProfileView, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<MainListView, MainListViewModel>();

        }
    }
}
