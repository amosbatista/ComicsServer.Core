using System.Collections.Generic;

namespace AmosBatista.ComicsServer.Core.Data.Context
{
    public class Page
    {
        public int pageID { get; set; }
        public List<Map> Maps { get; set; }
        public string Path { get; set; }
        public int episodeNumber { get; set; }
   }
}
