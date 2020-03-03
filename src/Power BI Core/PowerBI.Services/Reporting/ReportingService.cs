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
            return GetReports().ToDictionary(r => r.ReportId.ToString(), r => r.DisplayName);
            //return new Dictionary<string, string> { { "1", "2016 Election" } };
        }

        public async Task<EmbedReport> GetEmbedReportAsync(int reportId)
        {
            var report = GetReport(reportId);
            //_reportingContext.Reports.SingleOrDefault(r => r.ReportId == reportId);

            var embedReport = await _powerBIEmbedService.GetEmbeddedReportAsync(AuthenticationType.MasterAccount, new Guid(report.PowerBIReportId), new Guid(report.PowerBIGroupId));

            return embedReport;
        }

        public async Task<EmbedReport> GetEmbedReportAsync(int reportId, string userName)
        {
            var report = GetReport(reportId);
            //_reportingContext.Reports.SingleOrDefault(r => r.ReportId == reportId);

            var embedReport = await _powerBIEmbedService.GetEmbeddedReportAsync(AuthenticationType.MasterAccount, new Guid(report.PowerBIGroupId), new Guid(report.PowerBIGroupId));//, userName, report.ReportRoles.Select(rr => rr.RoleName).ToArray());

            return embedReport;
        }

        private Report GetReport(int reportId)
        {
            
            return GetReports().SingleOrDefault(r => r.ReportId == reportId);
        }

        private List<Report> GetReports()
        {
            var reports = new List<Report>()
            {
                new Report { ReportId = 1, DisplayName = "2016 Election", ReportName = "2016 Election", PowerBIGroupId = "0cdab667-3b3f-4a88-8c21-4eb0416470ef", PowerBIReportId = "398dab5c-5355-4128-9807-3fa9dd136f10", ReportRoles = new List<ReportRole>() }
            };

            return reports;
        }
    }
}
