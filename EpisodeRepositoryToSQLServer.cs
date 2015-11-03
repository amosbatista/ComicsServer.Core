using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AmosBatista.ComicsServer.Core
{
    public class EpisodeRepositoryToSQLServer:IEpisodeRepository 
    {

        public IEpisode Buscar(IParametrosPesquisaEpisodio parametrosPesquisa) 
        {

            // Definindo comando SQL
            SqlCommand sqlCommand = new SqlCommand("SELECT E.CONTEUDO_JSON FROM EPISODIOS E WHERE E.NUMEROEPISODIO = @NUMEROEPISODIO AND E.IDIOMA = @IDIOMA");

            // Configurando o valor do parâmetro
            foreach (KeyValuePair<string, string> _paramentroEpisodio in parametrosPesquisa.RetornarParametros())
            {
                sqlCommand.Parameters.AddWithValue(_paramentroEpisodio.Key, _paramentroEpisodio.Value);
            }

            try
            {
                // Pesquisando o JSON correspondente
                DataSet dataSet = SQLOperation.ExecuteSQLCommandWithResult(sqlCommand);
                BasicStyleEpisodeContent episodeContent = new BasicStyleEpisodeContent();
                episodeContent.JSONEpisode = (string)dataSet.Tables[0].Rows[0][0];
                Episode episode = new Episode();
                episode.EpisodeContent = episodeContent;
                return episode;
            }
            catch (Exception e) // Em qualquer caso de erro, retornar nulo.
            {
                return null;
            }
            finally
            {
                // Encerrando objetos
                sqlCommand.Dispose();
            }
        }

        public void Salvar(IEpisode episodio)
        {
            // Definindo comando SQL
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO EPISODIOS (NUMEROEPISODIO, IDIOMA, CONTEUDO_JSON) VALUES (@NUMEROEPISODIO, @IDIOMA, @CONTEUDO_JSON)");

            // Configurando o valor dos parâmetros
            sqlCommand.Parameters.AddWithValue("NUMEROEPISODIO", episodio.EpisodeNumber );
            sqlCommand.Parameters.AddWithValue("IDIOMA", episodio.Idiom);
            sqlCommand.Parameters.AddWithValue("CONTEUDO_JSON", episodio.EpisodeContent.ToJSONString());

            SQLOperation.ExecuteSQLCommand(sqlCommand);

        }


    }
}
