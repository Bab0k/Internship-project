using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_project.Model.Language
{
    public class English: Base
    {
        public English()
        {
            Title = "English";

            mainList = new MainList
            {
                Title = "MainList",
                Delete = "Delete",
                Edit = "Edit"
            };
            profile = new Profile
            {
                Title = "Profile",
                Name = "Name",
                NickName = "NickName",
                Description = "Description"
            };
            signIn = new SignIn
            {
                Title = "SignIn",
                Login = "Login",
                Password = "Password",
                Error = "Error",
                Cancel = "Cancel",
                MissingLoginOrPassword = "Missing Login or Password",
                Signin = "Sign in",
                Signup = "SIGN UP"
            };
            signUp = new SignUp
            {
                Title = "SignUp",
                Login = "Login",
                Password = "Password",
                ConfirmPassword = "Confirm Password",
                Error = "Error",
                Cancel = "Cancel",
                LoginExist = "this login exists",
                LoginNonValidation = "Login be at least 4 and no more then 16 and starting at letter",
                PasswordNonValidation = "Password be at least 4 and no more then 16 and must contain at least one uppercase letter, one  lovercase letter and one number",
                PasswordMismatch = "Password mismatch",
                Signup = "Sign up"
            };
            settings = new Settings
            {
                Title = "Settings",
                SortBy = "Sort by",
                Name = "Name",
                NickName = "NickName",
                Date = "Date",
                ApplicationLanguage = "Application Language"
            };
        }
    }
}
