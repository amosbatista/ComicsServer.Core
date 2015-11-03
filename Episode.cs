using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmosBatista.ComicsServer.Core
{
    public class Episode:IEpisode
    {
        // Implementing the episode content
        public IEpisodeContent EpisodeContent { get; set; }

        public int EpisodeNumber { get; set; }

        public string Idiom { get; set; }
    }
}