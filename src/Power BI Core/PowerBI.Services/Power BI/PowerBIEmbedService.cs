using PowerBI.Models.Configuration;
using PowerBI.Models.Embeddings;
using PowerBI.Services.Power_BI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PowerBI.Constants.Enums;

namespace PowerBI.Services.Power_BI
{
    public class PowerBIEmbedService : PowerBIServiceBase, IPowerBIEmbedService
    {
        public PowerBIEmbedService(PowerBIConfig powerBIConfig): base(powerBIConfig)
        {

        }

        public async Task<EmbedReport> GetEmbeddedReportBySPNAsync()
        {
            using var client = await GetClientAsync(AuthenticationType.ServicePrincipal);
            
            return new EmbedReport();
        }

        public async Task<EmbedReport> GetEmbeddedReportBySPNAsync(string userName)
        {
            using var client = await GetClientAsync(AuthenticationType.ServicePrincipal);

            return new EmbedReport();
        }

        public async Task<EmbedReport> GetEmbeddedReportBySPNAsync(string userName, params string[] roles)
        {
            using var client = await GetClientAsync(AuthenticationType.ServicePrincipal);

            return new EmbedReport();
        }
    }
}
