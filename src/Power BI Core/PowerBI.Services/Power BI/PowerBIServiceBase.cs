using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PowerBI.Models.ActiveDirectory;
using PowerBI.Models.Configuration;
using PowerBI.Models.Embeddings;
using PowerBI.Services.Power_BI.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static PowerBI.Constants.Enums;

namespace PowerBI.Services.Power_BI
{
    public class PowerBIServiceBase
    {
        private readonly PowerBIConfig _powerBIConfig;
        private IMemoryCache _memoryCache;

        public PowerBIServiceBase(IMemoryCache memoryCache, IOptions<PowerBIConfig> powerBIConfig)
        {
            _powerBIConfig = powerBIConfig.Value;
            _memoryCache = memoryCache;
        }

        protected async Task<PowerBIClient> GetClientAsync(AuthenticationType authenticationType)
        {
            return new PowerBIClient(new Uri(_powerBIConfig.ApiUrl), authenticationType == AuthenticationType.MasterAccount ? await GetAccessTokenByMasterAsync() : await GetAccessTokenBySPNAsync());
        }

        private async Task<TokenCredentials> GetAccessTokenBySPNAsync()
        {
            var authenticationContext = new AuthenticationContext(_powerBIConfig.AuthorityUrl);

            var credential = new ClientCredential(_powerBIConfig.SPNClientId, _powerBIConfig.SPNClientKey);

            var authenticationResult = await authenticationContext.AcquireTokenAsync(_powerBIConfig.ResourceUrl, credential);

            return new TokenCredentials(authenticationResult.AccessToken, "Bearer");
        }

        private async Task<TokenCredentials> GetAccessTokenByMasterAsync()
        {
            string token;
            DateTime updateTime;

            if (_memoryCache.TryGetValue<string>(Constants.Constants.PowerBIAccessToken, out token) 
                    && _memoryCache.TryGetValue<DateTime>(Constants.Constants.PowerBIAccessTokenUpdateTime, out updateTime))
            {
                if (DateTime.Compare(updateTime, DateTime.Now) > 0)
                {
                    return new TokenCredentials(token, "Bearer");
                }
            }

            var oauthEndpoint = new Uri(_powerBIConfig.MasterOAuth2Url);

            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(oauthEndpoint, new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("resource", _powerBIConfig.ResourceUrl),
                    new KeyValuePair<string, string>("client_id", _powerBIConfig.MasterClientId),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", _powerBIConfig.MasterId),
                    new KeyValuePair<string, string>("password", _powerBIConfig.MasterKey),
                    new KeyValuePair<string, string>("scope", "openid"),
                    }));

                var content = await result.Content.ReadAsStringAsync();

                var oAuthResult = JsonConvert.DeserializeObject<OAuthResult>(content);

                _memoryCache.CreateEntry(Constants.Constants.PowerBIAccessToken).SetValue(oAuthResult.AccessToken);

                _memoryCache.CreateEntry(Constants.Constants.PowerBIAccessTokenUpdateTime).SetValue(DateTime.Now.AddMinutes(30));

                return new TokenCredentials(oAuthResult.AccessToken, "Bearer");
            }
        }
    }
}
