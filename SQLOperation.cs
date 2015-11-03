using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;


namespace AmosBatista.ComicsServer.Core
{
    public class SQLOperation
    {
        public static DataSet ExecuteSQLCommandWithResult(SqlCommand sqlCommand)
        {
            //Setting command connection
            sqlCommand.Connection = generateConnection();
            
            // Setting data Adapter
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            
            // Setting data reader
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "table");

            // Returning genreated data set
            return dataSet;

        }

        public static void ExecuteSQLCommand(SqlCommand sqlCommand)
        {
            //Setting command connection
            sqlCommand.Connection = generateConnection();

            //Execute command
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();

        }

        private static SqlConnection generateConnection()
        {

            // Getting connection 
            String sqlConnectionString = Properties.Settings.Default.ComicsServerConnectionString;

            // Setting connection
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);

            return sqlConnection;
            
        }



    }

}