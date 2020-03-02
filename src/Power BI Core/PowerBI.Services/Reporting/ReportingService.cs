using PowerBI.Data.Reporting;
using PowerBI.Models.Embeddings;
using PowerBI.Services.Power_BI.Interfaces;
using PowerBI.Services.Reporting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PowerBI.Constants.Enums;

namespace PowerBI.Services.Reporting
{
    public class ReportingService: IReportingService
    {
        public readonly IPowerBIEmbedService _powerBIEmbedService;
        //public readonly ReportingContext _reportingContext;

        public ReportingService(IPowerBIEmbedService powerBIEmbedService)//, ReportingContext reportingContext)
        {
            _powerBIEmbedService = powerBIEmbedService;
           // _reportingContext = reportingContext;
        }

        public async Task<Dictionary<string, string>> GetReportsAsync()
        {
            return new Dictionary<string, string> { { "1", "Test" } };
        }

        public async Task<EmbedReport> GetEmbedReportAsync(int reportId)
        {
            var report = new Report() { };
                //_reportingContext.Reports.SingleOrDefault(r => r.ReportId == reportId);

            var embedReport = await _powerBIEmbedService.GetEmbeddedReportAsync(AuthenticationType.ServicePrincipal, new Guid(report.PowerBIGroupId), new Guid(report.PowerBIGroupId));

            return embedReport;
        }

        public async Task<EmbedReport> GetEmbedReportAsync(int reportId, string userName)
        {
            var report = new Report() {  };
                //_reportingContext.Reports.SingleOrDefault(r => r.ReportId == reportId);

            var embedReport = await _powerBIEmbedService.GetEmbeddedReportAsync(AuthenticationType.ServicePrincipal, new Guid(report.PowerBIGroupId), new Guid(report.PowerBIGroupId), userName, report.ReportRoles.Select(rr => rr.RoleName).ToArray());

            return embedReport;
        }
    }
}
