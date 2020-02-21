using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerBI.Models.Embeddings;

namespace PowerBI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbedReportController : ControllerBase
    {
        private readonly ILogger<EmbedReportController> _logger;

        public EmbedReportController(ILogger<EmbedReportController> logger)
        {

        }

        [HttpGet]
        public async Task<EmbedReport> GetAsync()
        {
            return new EmbedReport();
        }
    }
}