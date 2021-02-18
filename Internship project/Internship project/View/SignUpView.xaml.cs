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
    public partial class SignUpView : ContentPage
    {
        public Command SignUp_Clicked { get; }

        public SignUpView()
        {
            InitializeComponent();

        }

        private bool CheckLogin()
        {
            return true;
        }

        private void SignUp_Clicked_1(object sender, EventArgs e)
        {


        }
    }
}