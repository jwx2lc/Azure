using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class Report
    {
        public Report()
        {
            ReportRole = new HashSet<ReportRole>();
            ReportVisual = new HashSet<ReportVisual>();
        }

        public int ReportId { get; set; }
        public string DisplayName { get; set; }
        public string ReportName { get; set; }
        public Guid PowerBIReportId { get; set; }
        public Guid PowerBIGroupId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<ReportRole> ReportRole { get; set; }
        public virtual ICollection<ReportVisual> ReportVisual { get; set; }
    }
}
