using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Internship_project.Validation
{
    static class Validation
    {
        private static string uppercase = @"\w*[A-Z]+\w";
        private static string lovercase = @"\w*[a-z]+\w*";
        private static string number = @"\w*[0-9]+\w*";
        private static string loginlen = @"^\w{4,16}";
        private static string Passwordlen = @"^\w{6,16}";
        public static string start = @"^[a-zA-Z]+\w*";

        public static bool IsLogin(string text)
        {
            return IsValidation(text, uppercase)
                && IsValidation(text, lovercase)
                && IsValidation(text, number)
                && IsValidation(text, loginlen)
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
            return Regex.IsMatch(text, pattern);
        }
    }

}
