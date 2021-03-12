using Internship_project.Model.Language;
using Internship_project.Model.Tables;
using Internship_project.Model.UserData;
using Internship_project.Services.Settings;
using Internship_project.View;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Internship_project.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Properties

        bool _ByName;
        public bool ByName
        {
            get => _ByName;
            set => SetProperty(ref _ByName, value);
        }
        bool _ByNickName;
        public bool ByNickName
        {
            get => _ByNickName;
            set => SetProperty(ref _ByNickName, value);
        }
        bool _ByDate;
        public bool ByDate
        {
            get => _ByDate;
            set => SetProperty(ref _ByDate, value);
        }

        bool _DarkTheme;
        public bool DarkTheme
        {
            get => _DarkTheme;
            set => SetProperty(ref _DarkTheme, value);
        }

        string _language;
        public string language
        {
            get => _language;
            set => SetProperty(ref _language, value);
        }

        Base.Settings _Language;
        public Base.Settings Language
        {
            get => _Language;
            set => SetProperty(ref _Language, value);
        }

        public string Name { get; set; }
        public string NickName { get; set; }
        public string Date { get; set; }
        public string Sort { get; set; }
        public string ApplicationLanguage { get; set; }

        #endregion
        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Init();
        }

        private void Init()
        {
            Language = UserData.settings.GetLanguage().settings;

            Name = Language.Name;
            NickName = Language.NickName;
            Date = Language.Date;
            Sort = Language.SortBy;
            ApplicationLanguage = Language.ApplicationLanguage;
            Title = Language.Title;

            if (UserData.settings.GetOrderType() == "Date")
            {
                ByDate = true;
            }
            if (UserData.settings.GetOrderType() == "Name")
            {
                ByName = true;
            }
            if (UserData.settings.GetOrderType() == "NickName")
            {
                ByNickName = true;
            }
        }

        private void saveData()
        {
            Settings settings = new Settings();

            if (language != null)
            {
                if (language.Equals("English"))
                {
                    settings.Language = new English();
                }
                if (language.Equals("Русский"))
                {
                    settings.Language = new Russian();
                }
            }
            else
            {
                settings.Language = UserData.settings.GetLanguage();
            }

            settings.OrderType = UserData.settings.GetOrderType();

            if (ByName)
            {
                settings.OrderType = "Name";
            }
            if (ByNickName)
            {
                settings.OrderType = "NickName";
            }
            if (ByDate)
            {
                settings.OrderType = "Date";
            }

            UserData.settings = settings;

            NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainListView)}");


        }
        private void ChangeThame()
        {
            if (Application.Current.UserAppTheme == OSAppTheme.Light)
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
        }
        public DelegateCommand OnChangeThame =>
            new DelegateCommand(ChangeThame);

        public DelegateCommand SaveData =>
            new DelegateCommand(saveData);


    }
}
