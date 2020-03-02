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
        Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid reportId, Guid groupId);

        Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid reportId, Guid groupId, string userName, string[] roles);
    }
}
