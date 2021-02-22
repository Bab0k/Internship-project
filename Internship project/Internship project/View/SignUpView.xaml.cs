using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Realms;
using System.IO;
using Internship_project.ViewModel;
using Internship_project.Model.Tables;

namespace Internship_project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpView : ContentPage
    {
        string DATABASE_NAME = "ProfileBook.db";


        public SignUpView()
        {
            InitializeComponent();
            SignUp.IsEnabled = false;
        }

        private bool CheckValidation(IQueryable<User> users)
        {
            SignUpViewModel model = BindingContext as SignUpViewModel;

            if (users.Where(u => u.Login == model.Login).Any())
            {
                DisplayAlert("Error", "this login exists", "Cancel");

                return false;
            }

            if (model.Password.Length < 4 && model.Password.Length > 16)
            {
                DisplayAlert("Error", "Password be at least 4 and no more then 16" +
                    "and must contain at least one uppercase letter," +
                    "one  lovercase letter and one number", "Cancel");
                return false;
            }
            if (model.Password != model.ConfirmUserPassword)
            {
                DisplayAlert("Error", "Password mismatch", "Cancel");

                return false;
            }


            return true;
        }

        private void UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignUpViewModel model = BindingContext as SignUpViewModel;

            string numbers = "1234567890";

            if (!string.IsNullOrEmpty(model.Login))
            {
                if (numbers.Contains(model.Login.First()))
                {
                    model.Login = string.Empty;
                    return;
                }
            }

            SignUp.IsEnabled = !string.IsNullOrEmpty(model.Login) && !string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.ConfirmUserPassword);

        }

        private void SignUp_Clicked(object sender, EventArgs e)
        {
            SignUpViewModel model = BindingContext as SignUpViewModel;

            Realm _realm = Realm.GetInstance();
            Transaction _transaction = _realm.BeginWrite();

            var Users = _realm.All<User>();

            if (CheckValidation(Users))
            {

                _realm.Add(new User
                {
                    Login = model.Login,
                    Password = model.Password
                });


                model.NavigationCommand.Execute();
            }


            _transaction.Commit();

            _transaction.Dispose();


        }

    }
}