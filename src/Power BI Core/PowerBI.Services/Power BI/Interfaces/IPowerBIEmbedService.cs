using PowerBI.Models.Embeddings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PowerBI.Constants.Enums;

namespace PowerBI.Services.Power_BI.Interfaces
{
    public interface IPowerBIEmbedService
    {
        Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid groupId, Guid reportId);

        Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid groupId, Guid reportId, string userName);

        Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid groupId, Guid reportId, string userName, params string[] roles);
    }
}
