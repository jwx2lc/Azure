using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PowerBI.Data.Reporting
{
    public partial class ReportingContext : DbContext
    {
        public ReportingContext() { }

        public ReportingContext(DbContextOptions<ReportingContext> options) : base(options) { }

        public DbSet<Report> Reports { get; set; }
    }
}
