using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.Navigation;
using Realms;
using Internship_project.ViewModel;
using Internship_project.Model.Tables;

namespace Internship_project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInView : ContentPage
    {
        public SignInView()
        {
            InitializeComponent();
            SignIn.IsEnabled = false;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            string numbers = "1234567890";

            if (!string.IsNullOrEmpty(UserLogin.Text))
            {
                if (numbers.Contains(UserLogin.Text.First()))
                {
                    UserLogin.Text = string.Empty;
                    return;
                }
            }

            SignIn.IsEnabled = !string.IsNullOrEmpty(UserLogin.Text) && !string.IsNullOrEmpty(UserPassword.Text);

        }

        private void SignIn_Clicked(object sender, EventArgs e)
        {
            SignInViewModel model = BindingContext as SignInViewModel;

            Realm _realm = Realm.GetInstance();

            var Users = _realm.All<User>();

            if (CheckValidation(Users))
            {
                model.MainListViewNavigationCommand.Execute();
            }


        }

        private bool CheckValidation(IQueryable<User> users)
        {
            SignInViewModel model = BindingContext as SignInViewModel;

            if (users.Where(u => u.Login == model.Login && u.Password == model.Password).Any())
            {
                DisplayAlert("Error", "Missing login or password", "Cancel");

                return false;
            }
            return true;
        }
    }
}