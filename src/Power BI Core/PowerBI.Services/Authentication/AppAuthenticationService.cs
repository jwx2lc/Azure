using PowerBI.Data.ReportingDB;
using PowerBI.Models.Authentication;
using PowerBI.Services.Authentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerBI.Services.Authentication
{
    public class AppAuthenticationService: IAppAuthenticationService
    {
        public readonly ReportingContext _reportingContext;

        public AppAuthenticationService(ReportingContext reportingContext) =>_reportingContext = reportingContext;

        public UserModel AuthenticateUser(string userName)
        {
            var user = _reportingContext.User.SingleOrDefault(u => u.UserName == userName);

            return user == null ? null : new UserModel() { Username = user.UserName };
        }
    }
}
