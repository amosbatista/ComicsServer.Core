using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmosBatista.ComicsServer.Core
{
    public interface IEpisodeContent
    {
        // Function to return the JSON representation of the episode. 
        string ToJSONString();
    }
}