using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_project.Model.Language
{
    public class Base
    {
        public string Title;
        public MainList mainList;
        public Profile profile;
        public SignIn signIn;
        public SignUp signUp;
        public Settings settings;
        public class MainList
        {
            public string Title;
            public string Delete;
            public string Edit;
        }
        public class Profile
        {
            public string Title;
            public string NickName;
            public string Name;
            public string Description;
        }
        public class SignIn
        {
            public string Title;
            public string Login;
            public string Password;
            public string Error;
            public string MissingLoginOrPassword;
            public string Cancel;
            public string Signin;
            public string Signup;
        }
        public class SignUp
        {
            public string Title;
            public string Login;
            public string Password;
            public string ConfirmPassword;
            public string Error;
            public string Cancel;
            public string LoginExist;
            public string LoginNonValidation;
            public string PasswordNonValidation;
            public string PasswordMismatch;
            public string Signup;
        }
        public class Settings
        {
            public string Title;
            public string Name;
            public string NickName;
            public string Date;
            public string SortBy;
            public string ApplicationLanguage;
        }
    }
}
