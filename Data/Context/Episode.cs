using System.Collections.Generic;

namespace AmosBatista.ComicsServer.Core.Data.Context
{
    public class Episode
    {
        public int EpisodeNumber { get; set; }
        public string Idiom { get; set; }
        public List<Page> Pages { get; set; }
        public string Prologue { get; set; }
        public string Title { get; set; }
        public string ImgHeaderPath { get; set; }
    }
}
