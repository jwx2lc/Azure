using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerBI.Models.Embeddings;
using PowerBI.Services.Power_BI.Interfaces;

namespace PowerBI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbedReportController : ControllerBase
    {
        private readonly ILogger<EmbedReportController> _logger;
        private readonly IPowerBIEmbedService _powerBIEmbedService;

        public EmbedReportController(ILogger<EmbedReportController> logger, IPowerBIEmbedService powerBIEmbedService)
        {
            _logger = logger;
            _powerBIEmbedService = powerBIEmbedService;
        }

        [HttpGet]
        public async Task<EmbedReport> GetAsync()
        {
            return new EmbedReport();
        }
    }
}