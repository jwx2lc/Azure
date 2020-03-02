using System;
using System.Collections.Generic;

namespace PowerBI.Models.Embeddings
{
    public class EmbedReport
    {
        public string EmbedToken { get; set; }
        public string EmbedUrl { get; set; }
        public string PowerBIReportId { get; set; }
        public int LocationId { get; set; }
        public List<string> Errors { get; set; }
    }
}
