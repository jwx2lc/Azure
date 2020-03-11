using PowerBI.Models.Embeddings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerBI.Services.Reporting.Interfaces
{
    public interface IReportingService
    {
        Task<Dictionary<string, string>> GetReportsAsync(string userName);

        Task<EmbedReport> GetEmbedReportAsync(int reportId, string userName);
    }
}
