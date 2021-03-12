using Internship_project.Model.Language;
using Internship_project.Model.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Internship_project.Services.Settings
{
    public interface ISettings
    {
        ObservableCollection<Profile> OrderBy(ObservableCollection<Profile> profiles);
        Base GetLanguage();
        string GetOrderType();
    }
}
