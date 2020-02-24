using PowerBI.Models.Embeddings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerBI.Services.Power_BI.Interfaces
{
    public interface IPowerBIEmbedService
    {
        Task<EmbedReport> GetEmbeddingAsync();
    }
}
