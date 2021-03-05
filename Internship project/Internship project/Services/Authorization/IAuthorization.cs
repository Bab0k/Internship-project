using Internship_project.Model.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Internship_project.Services.Authorization
{
    interface IAuthorization
    {
        bool IsAutorization();
        bool Authorization(string Login, string Password);

    }
}
