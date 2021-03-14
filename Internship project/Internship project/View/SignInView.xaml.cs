using Internship_project.ViewModel;
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
        private void UserLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            SignIn.IsEnabled = (BindingContext as SignInViewModel).UserLogin_TextChanged(sender, e);
        }

    }
}