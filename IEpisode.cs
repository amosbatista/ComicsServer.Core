using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmosBatista.ComicsServer.Core
{
    public interface IEpisode
    {
        // Property that represents to content of episode
        IEpisodeContent EpisodeContent { get; set; }

        int EpisodeNumber { get; set; }

        string Idiom { get; set; }
    }
}