using AmosBatista.ComicsServer.Core.Data.Context;
using AmosBatista.ComicsServer.Core;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace AmosBatista.ComicsServer.Core.Data.Repository
{
    // Repository class, which will acess all data from Database
    public class MapRepository
    {

        // Lookup one Map and return it if is found
        public List<Map> LoadMapsByPageID(int pageId)
        {

            var sqlCommand = new SqlCommand("SELECT mapid, scale, X, y from MAPS WHERE PAGEID = @PAGEID order by mapid asc");
            sqlCommand.Parameters.AddWithValue("PAGEID", pageId);

            var dt = SQLOperation.ExecuteSQLCommandWithResult(sqlCommand);

            if (dt.Tables[0].Rows.Count <= 0)
            {
                return null;
            }

            var mapList = new List<Map>(dt.Tables[0].Rows.Count);

            for (int count = 0; count <= dt.Tables[0].Rows.Count - 1; count++)
            {
                var newMap = new Map();
                newMap.PageId = pageId;
                newMap.mapID = Int16.Parse( dt.Tables[0].Rows[count]["mapid"].ToString());
                newMap.Scale = Double.Parse(dt.Tables[0].Rows[count]["scale"].ToString());
                newMap.X = Int16.Parse(dt.Tables[0].Rows[count]["x"].ToString());
                newMap.Y = Int16.Parse(dt.Tables[0].Rows[count]["y"].ToString());

                mapList.Add(newMap);
            }

            return mapList;
        }

        // Save the map to the database
        public void Save(Map map)
        {

            var sqlCommand = new SqlCommand("INSERT INTO Maps(scale, X, Y, PageId) VALUES(@SCALE, @X, @Y, @PAGEID)");

            // Set parameters
            sqlCommand.Parameters.AddWithValue("SCALE", map.Scale);
            sqlCommand.Parameters.AddWithValue("X", map.X);
            sqlCommand.Parameters.AddWithValue("Y", map.Y);
            sqlCommand.Parameters.AddWithValue("PAGEID", map.PageId);

            SQLOperation.ExecuteSQLCommand(sqlCommand);
        }
    }
}