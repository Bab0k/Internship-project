﻿using Internship_project.Services.Authorization;
using Internship_project.View;
using Internship_project.ViewModel;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Realms;
using Xamarin.Forms;

namespace Internship_project
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null): base(initializer) { }

        IAuthorization authorization = new Authorization();

        protected override void OnInitialized()
        {

            Device.SetFlags(new string[] { "AppTheme_Experimental" });
            Device.SetFlags(new string[] { "RadioButton_Experimental" });

            InitializeComponent();

            var config = RealmConfiguration.DefaultConfiguration;
            config.SchemaVersion = 2;

            RealmConfiguration.DefaultConfiguration = config;

            if (authorization.IsAutorization())
            {
                NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(MainListView)}");
            }
            else
            {
                NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(SignInView)}");
            }
        }
        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignInView, SignInViewModel>();
            containerRegistry.RegisterForNavigation<SignUpView, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<ProfileView, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<MainListView, MainListViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
        }
    }
}
