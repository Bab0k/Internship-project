using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Internship_project.Validation
{
    static class Validation
    {
        private static readonly string uppercase = @"\w*[A-Z]+\w";
        private static readonly string lovercase = @"\w*[a-z]+\w*";
        private static readonly string number = @"\w*[0-9]+\w*";
        private static readonly string loginlen = @"^\w{4,16}";
        private static readonly string Passwordlen = @"^\w{6,16}";
        public static readonly string start = @"^[a-zA-Z]+\w*";

        public static bool IsLogin(string text)
        {
            return IsValidation(text, loginlen)
                && IsValidation(text, start);
        }
        public static bool IsPassword(string text)
        {
            return IsValidation(text, uppercase)
                && IsValidation(text, lovercase)
                && IsValidation(text, number)
                && IsValidation(text, Passwordlen)
                && IsValidation(text, start);
        }

        public static bool IsValidation(string text, string pattern)
        {
            var bll = Regex.IsMatch(text, pattern);
            return bll;
        }
    }
}
