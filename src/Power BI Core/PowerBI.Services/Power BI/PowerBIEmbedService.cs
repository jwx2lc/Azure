using Microsoft.Extensions.Options;
using Microsoft.PowerBI.Api.Models;
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
        public PowerBIEmbedService(IOptions<PowerBIConfig> powerBIConfig): base(powerBIConfig)
        {

        }

        public async Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid groupId, Guid reportId)
        {
            using var client = await GetClientAsync(authenticationType);

            var reportRequest = await client.Reports.GetReportInGroupWithHttpMessagesAsync(groupId, reportId);

            var report = reportRequest.Body;

            var requestParams = new GenerateTokenRequest(TokenAccessLevel.View);

            var response = await client.Reports.GenerateTokenInGroupWithHttpMessagesAsync(groupId, reportId, requestParams);

            var embedToken = response.Body;
            
            return new EmbedReport() { PowerBIReportId = report.Id.ToString(), EmbedUrl = report.EmbedUrl, EmbedToken = embedToken.Token };
        }

        public async Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid groupId, Guid reportId, string userName)
        {
            using var client = await GetClientAsync(AuthenticationType.ServicePrincipal);

            var reportRequest = await client.Reports.GetReportInGroupWithHttpMessagesAsync(groupId, reportId);

            var report = reportRequest.Body;

            var effectiveIdentity = new EffectiveIdentity()
            {
                Username = userName,
                Datasets = new List<string>() { report.DatasetId }
            };

            var requestParams = new GenerateTokenRequest(TokenAccessLevel.View, effectiveIdentity);

            var response = await client.Reports.GenerateTokenInGroupWithHttpMessagesAsync(groupId, reportId, requestParams);

            var embedToken = response.Body;

            return new EmbedReport() { PowerBIReportId = report.Id.ToString(), EmbedUrl = report.EmbedUrl, EmbedToken = embedToken.Token };
        }

        public async Task<EmbedReport> GetEmbeddedReportAsync(AuthenticationType authenticationType, Guid groupId, Guid reportId, string userName, params string[] roles)
        {
            using var client = await GetClientAsync(AuthenticationType.ServicePrincipal);

            var reportRequest = await client.Reports.GetReportInGroupWithHttpMessagesAsync(groupId, reportId);

            var report = reportRequest.Body;

            var effectiveIdentity = new EffectiveIdentity()
            {
                Username = userName,
                Datasets = new List<string>() { report.DatasetId }
            };

            var requestParams = new GenerateTokenRequest(TokenAccessLevel.View, effectiveIdentity);

            var response = await client.Reports.GenerateTokenInGroupWithHttpMessagesAsync(groupId, reportId, requestParams);

            var embedToken = response.Body;

            return new EmbedReport() { PowerBIReportId = report.Id.ToString(), EmbedUrl = report.EmbedUrl, EmbedToken = embedToken.Token };
        }
    }
}
