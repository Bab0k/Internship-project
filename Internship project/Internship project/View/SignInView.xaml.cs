using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void Button_Clicked(object sender, EventArgs e)
        {

            if (true)//Проверка данных
            {
                Navigation.PushAsync(new View.SignUpView());
            }



        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            string numbers = "1234567890";

            if (numbers.Contains(UserLogin.Text.FirstOrDefault()))
            {
                UserLogin.Text = "";
                return;
            }

            if (!string.IsNullOrEmpty(UserLogin.Text) && !string.IsNullOrEmpty(UserPassword.Text))
            {
                SignIn.IsEnabled = true;
            }

        }

        private void ToSignUp()
        {

        }
    }
}