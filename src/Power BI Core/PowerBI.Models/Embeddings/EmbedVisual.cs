using System;
using System.Collections.Generic;
using System.Text;

namespace PowerBI.Models.Embeddings
{
    public class EmbedVisual
    {
        public string PageName { get; set; }
        public string VisualName { get; set; }
        public int SortOrder { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
    }
}
