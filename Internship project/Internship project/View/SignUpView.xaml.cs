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
        public SignUpView()
        {
            InitializeComponent();
        }

        private void UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignUp.IsEnabled = (BindingContext as SignUpViewModel).UserLogin_TextChanged(sender, e);
        }
    }
}