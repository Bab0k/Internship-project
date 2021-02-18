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

    }
}