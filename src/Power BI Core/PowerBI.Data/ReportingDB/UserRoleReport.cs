using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class UserRoleReport
    {
        public int UserRoleReportId { get; set; }
        public int RoleId { get; set; }
        public int ReportId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Report Report { get; set; }
        public virtual Role Role { get; set; }
    }
}
