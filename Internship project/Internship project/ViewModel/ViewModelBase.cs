using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Internship_project.ViewModel
{
    public class ViewModelBase : BindableBase, IDestructible
    {

        public event PropertyChangedEventHandler propertyChanged;

        protected INavigationService NavigationService { get; private set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            propertyChanged?.Invoke(this, args);
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public void Destroy()
        {
        }
    }
}
