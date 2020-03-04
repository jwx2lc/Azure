using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class ReportRole
    {
        public int ReportRoleId { get; set; }
        public int ReportId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Report Report { get; set; }
    }
}
