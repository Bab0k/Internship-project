using Internship_project.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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