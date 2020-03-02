using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PowerBI.Data.Reporting
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }

        public string DisplayName { get; set; }

        [Required]
        public string ReportName { get; set; }

        [Required]
        public string PowerBIReportId { get; set; }

        [Required]
        public string PowerBIGroupId { get; set; }

        public virtual ICollection<ReportRole> ReportRoles { get; set; }

    }
}
