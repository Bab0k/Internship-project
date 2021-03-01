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
        private void UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignIn.IsEnabled = (BindingContext as SignInViewModel).UserLogin_TextChanged(sender, e);
        }

    }
}