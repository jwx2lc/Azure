using PowerBI.Models.Embeddings;
using PowerBI.Services.Power_BI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerBI.Services.Power_BI
{
    public class PowerBIEmbedService : PowerBIServiceBase, IPowerBIEmbedService
    {
        public PowerBIEmbedService()
        {

        }

        public Task<EmbedReport> GetEmbeddingAsync()
        {
            throw new NotImplementedException();
        }
    }
}
