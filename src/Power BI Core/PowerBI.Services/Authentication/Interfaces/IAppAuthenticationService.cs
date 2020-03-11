using PowerBI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerBI.Services.Authentication.Interfaces
{
    public interface IAppAuthenticationService
    {
        UserModel AuthenticateUser(string userName);
    }
}
