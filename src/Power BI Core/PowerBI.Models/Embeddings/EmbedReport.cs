using System;
using System.Collections.Generic;

namespace PowerBI.Models.Embeddings
{
    public class EmbedReport
    {
        public EmbedReport()
        {
            Errors = new List<string>();
            Visuals = new List<EmbedVisual>();
        }

        public string EmbedToken { get; set; }
        public string EmbedUrl { get; set; }
        public string PowerBIReportId { get; set; }
        public int LocationId { get; set; }
        public List<EmbedVisual> Visuals { get; set; }
        public List<string> Errors { get; set; }
    }
}
