using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class Report
    {
        public Report()
        {
            ReportSecurityRole = new HashSet<ReportSecurityRole>();
            ReportVisual = new HashSet<ReportVisual>();
            UserRoleReport = new HashSet<UserRoleReport>();
        }

        public int ReportId { get; set; }
        public string DisplayName { get; set; }
        public string ReportName { get; set; }
        public Guid PowerBIReportId { get; set; }
        public Guid PowerBIGroupId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<ReportSecurityRole> ReportSecurityRole { get; set; }
        public virtual ICollection<ReportVisual> ReportVisual { get; set; }
        public virtual ICollection<UserRoleReport> UserRoleReport { get; set; }
    }
}
