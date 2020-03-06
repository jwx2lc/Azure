using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerBI.Models.Embeddings;
using PowerBI.Services.Power_BI.Interfaces;
using PowerBI.Services.Reporting.Interfaces;

namespace PowerBI.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportAdminController : ControllerBase
    {
        private readonly ILogger<EmbedReportController> _logger;
        private readonly IReportingService _reportingService;

        public ReportAdminController(ILogger<EmbedReportController> logger, IReportingService reportingService)
        {
            _logger = logger;
            _reportingService = reportingService;
        }
    }
}