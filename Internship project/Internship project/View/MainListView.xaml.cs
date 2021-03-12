using Internship_project.Model.Tables;
using Internship_project.ViewModel;
using System;
using Xamarin.Forms;

namespace Internship_project.View
{
    public partial class MainListView : ContentPage
    {
        public MainListView()
        {
            InitializeComponent();
        }

        public void OnEdit(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Profile;
            (BindingContext as MainListViewModel).EditItem(item);
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var item = menu.CommandParameter as Profile;
            (BindingContext as MainListViewModel).DeleteItem(item);
        }
    }
}
