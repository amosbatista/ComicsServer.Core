using AmosBatista.ComicsServer.Core.Data.Context;
using System;
using AmosBatista.ComicsServer.Core;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AmosBatista.ComicsServer.Core.Data.Repository
{
    // Repository class, which will acess all data from Database
    public class PageRepository
    {

        // Lookup one Map and return it if is found
        public List<Page> LoadFromEpisode(int episodeNumber)
        {
            var sqlCommand = new SqlCommand("SELECT PAGEID, PATH from PAGES WHERE EPISODENUMBER = @EPISODENUMBER ORDER BY PAGEID ASC");
            sqlCommand.Parameters.AddWithValue("EPISODENUMBER", episodeNumber);

            var dt = SQLOperation.ExecuteSQLCommandWithResult(sqlCommand);

            if (dt.Tables[0].Rows.Count <= 0)
            {
                return null;
            }
            
            // Getting all pages
            var PageList = new List<Page>(dt.Tables[0].Rows.Count);
            var mapRep = new MapRepository();

            for (int count = 0; count <= dt.Tables[0].Rows.Count - 1; count++)
            {
                var newPage = new Page();
                newPage.episodeNumber = episodeNumber;
                newPage.pageID = Int16.Parse(dt.Tables[0].Rows[count]["PAGEID"].ToString());
                newPage.Path = dt.Tables[0].Rows[count]["Path"].ToString();
                
                // Getting the maps of each page
                newPage.Maps = mapRep.LoadMapsByPageID(newPage.pageID);

                PageList.Add(newPage);
            }

            return PageList;
        }

        // Save the map to the context
        public void Save(Page page)
        {

            var sqlCommand = new SqlCommand("INSERT INTO Pages(path, EpisodeNumber) VALUES(@path, @EPISODENUMBER)");

            // Set parameters
            sqlCommand.Parameters.AddWithValue("PATH", page.Path);
            sqlCommand.Parameters.AddWithValue("EPISODENUMBER", page.episodeNumber);
            
            SQLOperation.ExecuteSQLCommand(sqlCommand);

            // Select its ID
            sqlCommand = new SqlCommand("SELECT MAX (PAGEID) as PAGEID FROM PAGES");
            var dt = SQLOperation.ExecuteSQLCommandWithResult(sqlCommand);
            
            // Adding all maps
            var mapRep = new MapRepository();

            foreach (Map newMap in page.Maps){
                newMap.PageId = Int16.Parse(dt.Tables[0].Rows[0]["PAGEID"].ToString());
                mapRep.Save(newMap);
            }
        }
    }
}