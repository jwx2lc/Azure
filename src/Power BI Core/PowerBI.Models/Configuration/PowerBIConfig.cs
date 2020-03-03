using System;
using System.Collections.Generic;
using System.Text;

namespace PowerBI.Models.Configuration
{
    public class PowerBIConfig
    {
        public string ApiUrl { get; set; }
        public string AuthorityUrl { get; set; }
        public string MasterClientId { get; set; }
        public string MasterOAuth2Url { get; set; }
        public string MasterKey { get; set; }
        public string MasterId { get; set; }
        public string ResourceUrl { get; set; }
        public string SPNClientId { get; set; }
        public string SPNClientKey { get; set; }
    }
}
