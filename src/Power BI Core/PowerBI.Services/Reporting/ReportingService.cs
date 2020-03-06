using PowerBI.Data.ReportingDB;
using PowerBI.Models.Embeddings;
using PowerBI.Services.Power_BI.Interfaces;
using PowerBI.Services.Reporting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PowerBI.Constants.Enums;

namespace PowerBI.Services.Reporting
{
    public class ReportingService: IReportingService
    {
        public readonly IPowerBIEmbedService _powerBIEmbedService;
        public readonly ReportingContext _reportingContext;

        public ReportingService(IPowerBIEmbedService powerBIEmbedService, ReportingContext reportingContext)
        {
            _powerBIEmbedService = powerBIEmbedService;
            _reportingContext = reportingContext;
        }

        public async Task<Dictionary<string, string>> GetReportsAsync()
        {
            return _reportingContext.Report.ToDictionary(r => r.ReportId.ToString(), r => r.DisplayName);
        }

        public async Task<EmbedReport> GetEmbedReportAsync(int reportId)
        {
            var report = _reportingContext.Report.SingleOrDefault(r => r.ReportId == reportId);

            var embedReport = new EmbedReport();

            if (report == null)
            {
                embedReport.Errors = new List<string> { "Report not found!" };
            }
            else
            {
                embedReport = await _powerBIEmbedService.GetEmbeddedReportAsync(AuthenticationType.MasterAccount, report.PowerBIGroupId, report.PowerBIGroupId);//, userName, report.ReportRoles.Select(rr => rr.RoleName).ToArray());

                foreach (var viz in report.ReportVisual)
                {
                    embedReport.Visuals.Add(new EmbedVisual() { VisualName = viz.VisualName, PageName = viz.PageName, SortOrder = viz.SortOrder });
                }
            }

            return embedReport;
        }

        public async Task<EmbedReport> GetEmbedReportAsync(int reportId, string userName)
        {
            var report = _reportingContext.Report.SingleOrDefault(r => r.ReportId == reportId);

            var embedReport = report == null ? new EmbedReport() { Errors = new List<string> { "Report not found!" } }
                : await _powerBIEmbedService.GetEmbeddedReportAsync(AuthenticationType.MasterAccount, report.PowerBIGroupId, report.PowerBIGroupId);//, userName, report.ReportRoles.Select(rr => rr.RoleName).ToArray());

            return embedReport;
        }
    }
}
