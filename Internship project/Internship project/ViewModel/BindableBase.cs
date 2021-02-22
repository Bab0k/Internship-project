using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Internship_project.ViewModel
{
    public class BindableBase : Prism.Mvvm.BindableBase, INavigationAware, IDestructible
    {

        public PropertyChangedEventHandler propertyChanged;

        protected INavigationService NavigationService { get; private set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public BindableBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void Destroy()
        {
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
