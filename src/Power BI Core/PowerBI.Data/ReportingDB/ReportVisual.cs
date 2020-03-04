using System;
using System.Collections.Generic;

namespace PowerBI.Data.ReportingDB
{
    public partial class ReportVisual
    {
        public long ReportVisualId { get; set; }
        public int ReportId { get; set; }
        public string PageName { get; set; }
        public string VisualName { get; set; }
        public int SortOrder { get; set; }
        public int? PageLocationX { get; set; }
        public int? PageLocationY { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual Report Report { get; set; }
    }
}
