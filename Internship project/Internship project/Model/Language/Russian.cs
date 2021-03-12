using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_project.Model.Language
{
    class Russian: Base
    {
        public Russian()
        {
            Title = "Русский";

            mainList = new MainList
            {
                Title = "Главная станица",
            };
            profile = new Profile
            {
                Title = "Профиль",
                Name = "Имя",
                NickName = "Псевдоним",
                Description = "Описание"
            };
            signIn = new SignIn
            {
                Title = "Войти",
                Login = "Логин",
                Password = "Пароль",
                Error = "Ошибка",
                Cancel = "Назад",
                MissingLoginOrPassword = "Отсутствует логин или пароль",
                Signin = "Войти",
                Signup = "Зарегестрироваться"
            };
            signUp = new SignUp
            {
                Title = "Зарегистрироваться",
                Login = "Логин",
                Password = "Пароль",
                ConfirmPassword = "Подтвердить пароль",
                Error = "Ошибка",
                Cancel = "Назад",
                LoginExist = "Логин существует",
                LoginNonValidation = "Логин должен быть минимум 4 буквы и не больше 16",
                PasswordNonValidation = "Пароль должен быть не менее 4 и не более 16 и должен содержать как минимум одну заглавную букву, одну нижнюю букву и одну цифру.",
                PasswordMismatch = "Пароли не совпадают",
                Signup = "Зарегестрироваться"
            };
            settings = new Settings
            {
                Title = "Настройки",
                SortBy = "Сортировка по",
                Name = "Имени",
                NickName = "Псевдониму",
                Date = "Дате",
                ApplicationLanguage = "Язык приложения"
            };
        }

    }
}
