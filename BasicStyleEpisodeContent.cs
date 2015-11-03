using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmosBatista.ComicsServer.Core
{
    public class BasicStyleEpisodeContent : IEpisodeContent
    {   
        // This class will keep all the episode as JSON
        public string JSONEpisode { get; set; }

        // Return of the JSON Episode
        public string ToJSONString() {
            return JSONEpisode;
        }
    }
}