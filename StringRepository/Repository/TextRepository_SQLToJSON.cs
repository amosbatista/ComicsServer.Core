using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AmosBatista.ComicsServer.Core.StringRepository.Context;
using System;

namespace AmosBatista.ComicsServer.Core.StringRepository.Repository
{
    public class TextRepository_SQLToJSON : ITextRepository_Repository<Dictionary<string,string>, List<SimpleTranslation>>
    {
        public void SaveTextRepository(ITextRepository<Dictionary<string, string>> textRepository)
        {

            // After, run all the translations, and add
            foreach (KeyValuePair<string, string> _idiomTranslation in textRepository.translations())
            {
                var sqlCommand = new SqlCommand("INSERT INTO TEXT_TRANSLATIONS(DOM_ELEMENT_ID, IDIOM, TRANSLATION) VALUES(@DOM_ELEMENT_ID, @IDIOM, @TRANSLATION)");

                // Set parameters
                sqlCommand.Parameters.AddWithValue("DOM_ELEMENT_ID", textRepository.DOMElementID);
                sqlCommand.Parameters.AddWithValue("IDIOM", _idiomTranslation.Key);
                sqlCommand.Parameters.AddWithValue("TRANSLATION", _idiomTranslation.Value);

                SQLOperation.ExecuteSQLCommand(sqlCommand);
            }
        
        }

        public List<SimpleTranslation> LoadTextRepository()
        {
            SqlCommand sqlCommand = null;
            var translationList = new List<SimpleTranslation>();
            try
            {

                // Searching all repository
                sqlCommand = new SqlCommand("SELECT * FROM TEXT_TRANSLATIONS ORDER BY DOM_ELEMENT_ID");

                DataSet dataSet = SQLOperation.ExecuteSQLCommandWithResult(sqlCommand);
                SimpleTranslation simpleTranslation = new SimpleTranslation();

                int contRows = 0;
                do
                {

                    // Running all content, and build the repository. 
                    if (simpleTranslation.DOMElementID != dataSet.Tables[0].Rows[contRows]["DOM_ELEMENT_ID"].ToString())
                    {
                        if(simpleTranslation.DOMElementID != null)
                            //Save the last translation repository
                            translationList.Add(simpleTranslation);

                        simpleTranslation = new SimpleTranslation();
                        simpleTranslation.DOMElementID = dataSet.Tables[0].Rows[contRows]["DOM_ELEMENT_ID"].ToString();
                    }

                    // Now, set the translation
                    if(dataSet.Tables[0].Rows[contRows]["IDIOM"].ToString() == "PT")
                        simpleTranslation.PortugueseContent = dataSet.Tables[0].Rows[contRows]["TRANSLATION"].ToString();
                    else
                        simpleTranslation.EnglishContent = dataSet.Tables[0].Rows[contRows]["TRANSLATION"].ToString();

                    contRows++;

                } while (contRows < dataSet.Tables[0].Rows.Count);

                //Save the last translation repository
                translationList.Add(simpleTranslation);

                // With the translation repository complete, generate the JSON format
                return translationList;
            }
            catch (Exception e) // Em qualquer caso de erro, retornar nulo.
            {
                return null;
            }
            finally
            {
                // In all errors, return null
                sqlCommand.Dispose();
            }

        }

        // Function to create the table to the base, if it don't exist
        public void CreateRepositoryOnBase()
        {
            var sqlCommand = new SqlCommand("CREATE TABLE TEXT_TRANSLATIONS (DOM_ELEMENT_ID varchar(100) null, IDIOM varchar(10) null, TRANSLATION text)");
            SQLOperation.ExecuteSQLCommand(sqlCommand);
        }

        public TextRepository_SQLToJSON(bool addNewRecords )
        {
            SqlCommand sqlCommand = null;
            try
            {
                if (addNewRecords == true) // Only remove the existing records if is necessary
                {
                    // First of all, remove all translation records
                    sqlCommand = new SqlCommand("DELETE FROM TEXT_TRANSLATIONS");
                    SQLOperation.ExecuteSQLCommand(sqlCommand);
                }
            }
            catch (Exception e)
            {
                // If ocourrs an SQL error, telling the table don't exists, create the table.
                CreateRepositoryOnBase();
            }

        }
    }
}
