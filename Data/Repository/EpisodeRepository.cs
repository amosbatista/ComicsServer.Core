using AmosBatista.ComicsServer.Core.Data.Context;
using System;
using AmosBatista.ComicsServer.Core;
using System.Data.SqlClient;

namespace AmosBatista.ComicsServer.Core.Data.Repository
{
    // Repository class, which will acess all data from Database
    public class EpisodeRepository
    {

        // Lookup one Episode and return it if is found
        public Episode Load(int episodeNumber, string episodeIdiom)
        {
            var sqlCommand = new SqlCommand("SELECT * FROM EPISODES WHERE EPISODENUMBER = @EPISODENUMBER");
            sqlCommand.Parameters.AddWithValue("EPISODENUMBER", episodeNumber);
            var dt = SQLOperation.ExecuteSQLCommandWithResult(sqlCommand);

            if (dt.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            
            //Setting a loaded episode
            var episode = new Episode();
            episode.EpisodeNumber = Int16.Parse(dt.Tables[0].Rows[0]["EPISODENUMBER"].ToString());
            episode.Idiom = dt.Tables[0].Rows[0]["idiom"].ToString();

            // Loading all Episode pages
            var pageRep = new PageRepository();
            episode.Pages = pageRep.LoadFromEpisode(episode.EpisodeNumber);
            
            // Sending the episode
            return episode;
            
        }

        // Save the map to the context
        public void Save(Episode episode)
        {
            // First, find if another episode was inserted before
            if (this.EpisodeHasBeenLoaded(episode.EpisodeNumber, episode.Idiom) == false)
            {
                // If is not, insert a new episode
                var sqlCommand = new SqlCommand("INSERT INTO EPISODES(EpisodeNumber, IDIOM) VALUES(@EPISODENUMBER, @IDIOM)");
                // Set parameters
                sqlCommand.Parameters.AddWithValue("EPISODENUMBER", episode.EpisodeNumber);
                sqlCommand.Parameters.AddWithValue("IDIOM", episode.Idiom);
                SQLOperation.ExecuteSQLCommand(sqlCommand);
            }


            // Adding all pages
            var pageRep = new PageRepository();

            foreach (Page page in episode.Pages)
            {
                page.episodeNumber = episode.EpisodeNumber;
                pageRep.Save(page);
            }

        }

        // Lookup one Episode and return it if is found
        public bool EpisodeHasBeenLoaded(int episodeNumber, string episodeIdiom)
        {
            var sqlCommand = new SqlCommand("SELECT * FROM EPISODES WHERE EPISODENUMBER = @EPISODENUMBER");
            sqlCommand.Parameters.AddWithValue("EPISODENUMBER", episodeNumber);
            var dt = SQLOperation.ExecuteSQLCommandWithResult(sqlCommand);

            if (dt.Tables[0].Rows.Count <= 0)
                return false;
            else
                return true;
        

        }
    }
}
