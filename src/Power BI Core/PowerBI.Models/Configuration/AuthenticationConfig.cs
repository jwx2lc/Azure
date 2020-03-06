using System;
using System.Collections.Generic;
using System.Text;

namespace PowerBI.Models.Configuration
{
    public class AuthenticationConfig
    {
        public bool EnableSelfAuthentication { get; set; }
        public string Audience { get; set; }
        public string JwtEncryptionKey { get; set; }
    }
}
