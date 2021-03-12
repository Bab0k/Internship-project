using Internship_project.Model.Language;
using Internship_project.Model.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Internship_project.Services.Settings
{
    public class Settings : ISettings
    {
        private Base language;
        public string OrderType = "Date";
        public Base Language { get => language; set => language = value; }

        public Base GetLanguage()
        {
            return Language;
        }

        ObservableCollection<Profile> ISettings.OrderBy(ObservableCollection<Profile> profiles)
        {
            if (OrderType == "Name")
            {
                return new ObservableCollection<Profile>(profiles.OrderBy(u => u.Name));
            }
            else
            {
                if (OrderType == "NickName")
                {
                    return new ObservableCollection<Profile>(profiles.OrderBy(u => u.NickName));
                }
                else
                {
                    return new ObservableCollection <Profile>(profiles.OrderBy(u => u.Date));
                }
            }
        }

        public string GetOrderType()
        {
            return OrderType;
        }
    }
}
